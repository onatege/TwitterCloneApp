using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Seed
{
	public class UserSeed : IEntityTypeConfiguration<User>
	{
		

		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(
			new User
			{
				Id = 1,
				UserName = "TEST",
				DisplayName = "test1",
				Biography = "TEST",
				Email = "test123@gmail.com",
				Password = "test123",
				
			},
			new User
			{
				Id = 2,
				UserName = "TEST1",
				DisplayName = "test2",
				Biography = "TEST1",
				Email = "test111@gmail.com",
				Password = "test123",
				Followings = new List<Follow>(),
				Followers = new List<Follow>(),
				Likes = new List<Like>()

			},
			new User
			{
				Id = 3,
				UserName = "TEST3",
				DisplayName = "test3",
				Biography = "TEST2",
				Email = "test121@gmail.com",
				Password = "test123",
				Followings = new List<Follow>(),
				Followers = new List<Follow>(),
				Likes = new List<Like>()
			});
		}
	}
}
