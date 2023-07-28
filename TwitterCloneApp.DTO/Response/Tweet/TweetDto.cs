using TwitterCloneApp.DTO.Response.Reply;
using TwitterCloneApp.DTO.Response.Tag;
using TwitterCloneApp.DTO.Response.User;

namespace TwitterCloneApp.DTO.Response.Tweet
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
