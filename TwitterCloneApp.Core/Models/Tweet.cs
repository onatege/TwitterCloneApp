namespace TwitterCloneApp.Core.Models
{
    public class Tweet : BaseEntity
	{
		public int UserId { get; set; }
		public string Content { get; set; }
		public User User { get; set; }
		public bool isMainTweet { get; set; }
        public ICollection<Tag>? Tags { get; set; } // Many-to-Many ilişkisi için koleksiyon
    }
}
