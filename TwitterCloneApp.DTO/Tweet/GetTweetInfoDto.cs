namespace TwitterCloneApp.DTO.Tweet
{
    public class GetTweetInfoDto
    {
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; } 
        /* TODO
         * public int Like Count eklenecek.
         */
    }
}
