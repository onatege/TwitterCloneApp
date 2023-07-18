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
	public class TwReplySeed : IEntityTypeConfiguration<TwReply>
	{
		public void Configure(EntityTypeBuilder<TwReply> builder)
		{
			builder.HasData(new TwReply
			{
				TweetId = 1,
				ReplyId = 3,
			});
		}
	}
}
