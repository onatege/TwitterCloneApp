namespace TwitterCloneApp.DTO.Request.Tweet
{
    public class AddTweetDto
    {
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
