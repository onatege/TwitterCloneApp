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
	public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
	{
		public void Configure(EntityTypeBuilder<Tweet> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Content).IsRequired().HasMaxLength(400);

			builder.HasOne(x => x.User).WithMany(x => x.Tweets).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(x => x.Likes).WithOne(x => x.Tweet).HasForeignKey(x => x.TweetId).OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(x => x.Replies).WithOne(x => x.Tweet).HasForeignKey(x =>x.TweetId).OnDelete(DeleteBehavior.Cascade);

			builder.ToTable("Tweets");
		}
	}
}
