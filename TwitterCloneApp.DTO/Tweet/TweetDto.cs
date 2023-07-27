using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.DTO.Tag;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.DTO.Tweet
{
	public class TweetDto
	{
        public int Id { get; set; }
		//public int UserId { get; set; }
		public UserResponseDto User { get; set; }
		public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int LikeCount { get; set; }
		public List<TagResponseDto>? Tags { get; set; }
        public List<ReplyResponseDto> Replies { get; set; }
    }
}
