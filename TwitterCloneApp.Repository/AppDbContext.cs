using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.Repository.Seeds;

namespace TwitterCloneApp.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<TwReply> TwReplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            var relationships = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys());

            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
