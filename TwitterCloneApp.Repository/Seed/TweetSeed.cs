using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Seed
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

			},
			new Tweet
			{
				Id = 2,
				UserId = 1,
				Content = "Second tweet",

			},
			new Tweet
			{
				Id = 3,
				UserId = 2,
				Content = "Replied test tweet",

			}
			);
		}
	}
}
