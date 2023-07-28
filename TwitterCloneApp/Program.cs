using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

var builder = WebApplication.CreateBuilder(args);

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


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name));
});

builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
 //username aratmadan parola kaldir