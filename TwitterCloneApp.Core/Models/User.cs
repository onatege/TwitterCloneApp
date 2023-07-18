namespace TwitterCloneApp.Core.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isDeleted { get; set; }
        public string? Biography { get; set; }
        public string ProfileImg { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Follow> Followers { get; set; }
        public ICollection<Follow> Followings { get; set; }
    }
}
