using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Configurations
{
	public class LikeConfiguration : IEntityTypeConfiguration<Like>
	{
		public void Configure(EntityTypeBuilder<Like> builder)
		{
			builder.HasKey(x => new { x.UserId, x.TweetId });
			builder.ToTable("Likes");
		}
	}
}
