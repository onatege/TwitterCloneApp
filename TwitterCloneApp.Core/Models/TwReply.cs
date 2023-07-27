namespace TwitterCloneApp.Core.Models
{
    public class TwReply
    {
        public int TweetId { get; set; }
        public int ReplyId { get; set; }
        public Tweet Tweet { get; set; }
        public Reply Reply { get; set; }
    }
}
