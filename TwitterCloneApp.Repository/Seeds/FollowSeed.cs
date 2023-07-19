using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Seeds
{
    public class FollowSeed : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasData(
                new Follow
                {
                    FollowerId = 1,
                    FollowingId = 2
                },
                new Follow
                {
                    FollowerId = 1,
                    FollowingId = 3
                },
                new Follow
                {
                    FollowerId = 2,
                    FollowingId = 1
                },
                new Follow
                {
                    FollowerId = 3,
                    FollowingId = 1
                }
            );
        }
    }
}
