using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Seeds
{
    public class TweetSeed : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.HasData(
                new Tweet
                {
                    Id = 1,
                    UserId = 1,
                    Content = "First tweet",
                    isMainTweet = true
                },
                new Tweet
                {
                    Id = 2,
                    UserId = 1,
                    Content = "Second tweet",
                    isMainTweet = true
                },
                new Tweet
                {
                    Id = 3,
                    UserId = 2,
                    Content = "Replied test tweet",
                    isMainTweet = false
                }
            );
        }
    }
}
