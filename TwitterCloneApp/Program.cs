using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TwitterCloneApp.Caching.Abstracts;
using TwitterCloneApp.Caching.Concretes;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.Middlewares;
using TwitterCloneApp.Repository;
using TwitterCloneApp.Repository.Infrastructures;
using TwitterCloneApp.Repository.Repositories;
using TwitterCloneApp.Service.Concrete;
using TwitterCloneApp.Service.Filters;
using TwitterCloneApp.Service.Mapping;
using TwitterCloneApp.Service.Validations;
using Microsoft.IdentityModel.Tokens;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);
ConfigureLogging();
builder.Logging.AddSerilog();

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true); 

builder.Services.AddFluentValidation(v =>
{
    v.RegisterValidatorsFromAssemblyContaining<AddUserValidator>();
    v.RegisterValidatorsFromAssemblyContaining<UpdateUserValidator>();
    v.RegisterValidatorsFromAssemblyContaining<AddTweetValidator>();
	
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITweetRepository, TweetRepository>();
builder.Services.AddScoped<ITweetService, TweetService>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddScoped<ICacheService, RedisCacheService>();

builder.Services.AddScoped(typeof(NotFoundFilter<>));


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name));
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddAutoMapper(typeof(MapProfile));
Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Information()
			.WriteTo.Console()
			.WriteTo.File("log.txt",
				rollingInterval: RollingInterval.Day,
				rollOnFileSizeLimit: true)
			.CreateLogger();


var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseMiddleware<RequestResponseLogMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureLogging()
{
	var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
	var configuration = new ConfigurationBuilder()
		.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		.AddJsonFile(
			$"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
			optional: true)
		.Build();

	Log.Logger = new LoggerConfiguration()
		.Enrich.FromLogContext()
		.Enrich.WithMachineName()
		.WriteTo.Debug()
		.WriteTo.Console()
		.WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
		.Enrich.WithProperty("Environment", environment)
		.ReadFrom.Configuration(configuration)
		.CreateLogger();
}

ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
	return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
	{
		AutoRegisterTemplate = true,
		IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
	};
}