using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Core.DTOs
{
	public class TweetDTO : BaseDTO
	{
        // UserId, Content 
        public int UserId { get; set; }
        public string Content { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public ICollection<TwReply>? Replies { get; set; }


    }
}

