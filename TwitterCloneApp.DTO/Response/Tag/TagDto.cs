using TwitterCloneApp.DTO.Response.Tweet;

namespace TwitterCloneApp.DTO.Response.Tag
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TweetResponseDto> Tweets { get; set; }
    }
}
