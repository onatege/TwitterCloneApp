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
        /* 
         * Kullanıcı kaç Follower, Following'e sahip - kaç Tweet'e sahip eklenecek.
         *  public List<TweetSearchDto> Tweets { get; set; } - Tweet Controllerda yapılacak (Kullanıcıya ait tweetleri görme.
        */

    }
}
