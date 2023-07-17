namespace TwitterCloneApp.Core.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isDeleted { get; set; }
        public string Biography { get; set; }
        public string ProfileImg { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
