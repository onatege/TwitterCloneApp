using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Configurations
{
	public class TwReplyConfiguration : IEntityTypeConfiguration<TwReply>
	{
		public void Configure(EntityTypeBuilder<TwReply> builder)
		{
			builder.HasKey(tw => new { tw.TweetId, tw.ReplyId });
			builder.ToTable("Replies");

            /*
            builder.HasOne(r => r.Tweet)
                .WithMany()
                .HasForeignKey(r => r.TweetId)
                .OnDelete(DeleteBehavior.Restrict);
            */
        }
    }
}
