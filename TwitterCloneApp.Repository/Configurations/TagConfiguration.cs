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
	public class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Name).IsRequired().HasMaxLength(80);

			builder.HasMany(x => x.Tweets).WithMany(x => x.Tags).UsingEntity<Dictionary<string, object>>("TweetTag",x => x.HasOne<Tweet>().WithMany().HasForeignKey("TweetId"),
				a => a.HasOne<Tag>().WithMany().HasForeignKey("TagId"));

			builder.ToTable("Tags");
		}
	}
}
