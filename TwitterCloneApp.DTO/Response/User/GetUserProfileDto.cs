﻿using TwitterCloneApp.DTO.Response.Tweet;

namespace TwitterCloneApp.DTO.Response.User
{
    public class GetUserProfileDto
    {
        public int Id { get; set; }
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
