﻿namespace TwitterCloneApp.DTO.Response.Tweet
{
    public class TweetResponseDto
    {
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int LikeCount { get; set; }
    }
}