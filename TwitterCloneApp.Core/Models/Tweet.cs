namespace TwitterCloneApp.Core.Models
{
    public class Tweet : BaseEntity
	{
		public int UserId { get; set; }
		public string Content { get; set; }
		public bool isDeleted { get; set; }
		public User User { get; set; }
		public bool isMainTweet { get; set; }
		public DateTime? DeletedAt { get; set; }
		
		public ICollection<Like>? Likes { get; set; }
		public ICollection<Tag>? Tags { get; set; }
		public ICollection<TwReply>? Replies { get; set; }

		
	}
}
