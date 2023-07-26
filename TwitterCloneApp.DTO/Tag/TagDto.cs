using TwitterCloneApp.DTO.Tweet;

namespace TwitterCloneApp.DTO.Tag
{
    public class TagDto
    {
        public string Name { get; set; }
        public List<TweetResponseDto> Tweets { get; set; }
    }
}
