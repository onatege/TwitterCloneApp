using TwitterCloneApp.Core.Interfaces;

namespace TwitterCloneApp.Core.Models
{
    public class Tweet : IBaseEntity, IDeletable, IUpdatedAt, ICreatedAt
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Content { get; set; }
		public User User { get; set; }
		public bool isMainTweet { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? CreatedAt { get; set; }
        public ICollection<Tag>? Tags { get; set; } // Many-to-Many ilişkisi için koleksiyon
		public ICollection<Reply>? Replies { get; set; }
		public ICollection<Like>? Likes { get; set; }
    }
}
