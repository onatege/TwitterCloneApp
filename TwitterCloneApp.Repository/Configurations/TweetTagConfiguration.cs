using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Configurations
{
    public class TweetTagConfiguration : IEntityTypeConfiguration<TweetTag>
    {
        public void Configure(EntityTypeBuilder<TweetTag> builder)
        {
            builder.HasKey(x => new { x.TweetId, x.TagId });

            builder.ToTable("TweetTags");
        }
    }
}
