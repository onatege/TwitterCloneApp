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
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Password).IsRequired().HasMaxLength(20);
			builder.Property(x => x.Biography).HasMaxLength(30);
			builder.ToTable("Users");

			builder.HasMany(x => x.Tweets)
			.WithOne(x => x.User).HasForeignKey(x => x.UserId);
			builder.HasMany(x => x.Likes).WithOne(x => x.User).HasForeignKey(x => x.UserId);
			builder.HasMany(u => u.Followers)
			.WithOne(x => x.Follower)
			.HasForeignKey(x => x.FollowerId);
			builder.HasMany(u => u.Followings)
			.WithOne(f => f.Following)
			.HasForeignKey(f => f.FollowingId);


		}
	}
}
