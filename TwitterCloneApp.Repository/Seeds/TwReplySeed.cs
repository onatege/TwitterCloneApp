using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Seeds
{
    public class TwReplySeed : IEntityTypeConfiguration<TwReply>
    {
        public void Configure(EntityTypeBuilder<TwReply> builder)
        {
            builder.HasData(new TwReply
            {
                TweetId = 1,
                ReplyId = 3
            });
        }
    }
}
