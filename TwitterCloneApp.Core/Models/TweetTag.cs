namespace TwitterCloneApp.Core.Models
{
    public class TweetTag
    {
        public int TweetId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public Tweet Tweet { get; set; }
    }
}