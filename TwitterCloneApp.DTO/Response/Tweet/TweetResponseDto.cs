﻿namespace TwitterCloneApp.DTO.Response.Tweet
{
    public class TweetResponseDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int LikeCount { get; set; }
    }
}
