using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Configurations
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(x => new { x.FollowerId, x.FollowingId });

            /*builder.HasOne(x => x.Follower)
                   .WithMany()
                   .HasForeignKey(x => x.FollowerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Following)
                   .WithMany()
                   .HasForeignKey(x => x.FollowingId)
                   .OnDelete(DeleteBehavior.Restrict);
            */

            builder.ToTable("Follows");
        }
    }
}
