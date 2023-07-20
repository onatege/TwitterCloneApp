using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.DTO.Tweet
{
	public class TweetDto
	{
        public UsernameDto UserName { get; set; }
        public UserReplyDto RepliedUser { get; set; }
		public LikeDto Likes { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Content { get; set; }
    }
}
