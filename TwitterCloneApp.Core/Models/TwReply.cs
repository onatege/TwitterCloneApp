namespace TwitterCloneApp.Core.Models
{
    public class TwReply
    {
        public int TweetId { get; set; }
        public int ReplyId { get; set; }
        public virtual Tweet Tweet { get; set; }
        public virtual Tweet Reply { get; set; }
    }
}
