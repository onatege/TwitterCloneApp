using System.Runtime.Serialization;
using TwitterCloneApp.Core.Interfaces;

namespace TwitterCloneApp.Core.Models
{
    public class User : IBaseEntity, ICreatedAt, IUpdatedAt, IDeletable
    { 
        public int Id { get; set; }
		public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Biography { get; set; }
        public string? ProfileImg { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<Tweet>? Tweets { get; }
        [IgnoreDataMember]
        public virtual ICollection<Like>? Likes { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<User>? Followers { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<User>? Following { get; set; }
    }
}
