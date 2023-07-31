using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Seeds
{
    public class TagSeed : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasData(
                new Tag
                {
                    Id = 1,
                    Name = "#testingSeed1"
                },
                new Tag
                {
                    Id = 2,
                    Name = "#testingSeed2"
                }
            );
        }
    }
}
