using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.DTO.Tweet
{
    public class ReplyResponseDto
    {
        public UserResponseDto User { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
