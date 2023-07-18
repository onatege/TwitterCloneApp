using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Seed
{
	public class LikeSeed : IEntityTypeConfiguration<Like>
	{
		public void Configure(EntityTypeBuilder<Like> builder)
		{
			builder.HasData(new Like
			{
				TweetId = 1,
				UserId = 1,
			},
			new Like
			{
				TweetId = 1,
				UserId = 2,
			},
			new Like
			{
				TweetId = 1,
				UserId = 3,
			},
			new Like
			{
				TweetId = 2,
				UserId = 1,
			},
			new Like
			{
				TweetId = 2,
				UserId = 2,
			});
		}
	}
}
