namespace TwitterCloneApp.Core.Models
{
    public class Follow
    {
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }

        public virtual User Follower { get; set; }
        public virtual User Following { get; set; }
    }
}
