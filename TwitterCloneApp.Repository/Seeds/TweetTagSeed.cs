using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Seeds
{
    public class TweetTagSeed : IEntityTypeConfiguration<TweetTag>
    {
        public void Configure(EntityTypeBuilder<TweetTag> builder)
        {
            builder.HasData(
                new TweetTag
                {
                    TweetId = 1,
                    TagId = 1
                },
                new TweetTag
                {
                    TweetId = 1,
                    TagId = 2
                },
                new TweetTag
                {
                    TweetId = 2,
                    TagId = 1
                },
                new TweetTag
                {
                    TweetId = 3,
                    TagId = 1
                },
                new TweetTag
                {
                    TweetId = 3,
                    TagId = 2
                }
            );
        }
    }
}
