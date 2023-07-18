using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Configurations
{
	public class TwReplyConfiguration : IEntityTypeConfiguration<TwReply>
	{
		public void Configure(EntityTypeBuilder<TwReply> builder)
		{
			builder.HasKey(tw => new { tw.TweetId, tw.ReplyId });
			builder.ToTable("Replies");

		}
	}
}
