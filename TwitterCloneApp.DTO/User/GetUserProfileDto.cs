using TwitterCloneApp.DTO.Tweet;

namespace TwitterCloneApp.DTO.User
{
    public class GetUserProfileDto
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string? Biography { get; set; }
        public string? ProfileImg { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public List<TweetResponseDto> Tweets { get; set; }

    }
}
