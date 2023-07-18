namespace TwitterCloneApp.Core.Models
{
    public class Like 
	{
		public int TweetId { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public Tweet Tweet { get; set; }

	}
}
