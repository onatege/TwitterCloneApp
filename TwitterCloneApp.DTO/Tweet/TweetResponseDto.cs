using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.DTO.Tweet
{
    public class TweetResponseDto
    {
        public UserResponseDto User { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int LikeCount { get; set; }
    }
}
