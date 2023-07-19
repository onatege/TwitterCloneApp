using TwitterCloneApp.Core.Abstracts;

namespace TwitterCloneApp.Core.Models
{
    public class User : IBaseEntity
    {
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool isDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }

		public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Biography { get; set; }
        public string? ProfileImg { get; set; }
    }
}
