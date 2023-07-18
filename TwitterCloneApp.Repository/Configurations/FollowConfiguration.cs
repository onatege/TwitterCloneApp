using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Configurations
{
	public class FollowConfiguration : IEntityTypeConfiguration<Follow>
	{
		public void Configure(EntityTypeBuilder<Follow> builder)
		{
			builder.HasKey(x => new { x.FollowerId, x.FollowingId });

			builder.ToTable("Follows");
		}
	}
}
