using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Seed
{
	public class TagSeed : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.HasData(
			
			new Tag
			{
				Id = 1,
				Name = "#testingSeed",
				Tweets = new List<Tweet>
				{
					new Tweet { Id = 5, Content = "TEST", UserId = 1 },
				}
			},
			new Tag
			{
				Id = 1,
				Name = "#testingSeed2",
				Tweets = new List<Tweet>
				{
					new Tweet { Id = 6, Content = "TEST", UserId = 3 },
				}
			});
		}
	}
}
