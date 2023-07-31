using TwitterCloneApp.Core.Interfaces;

namespace TwitterCloneApp.Core.Models
{
    public class Tag : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tweet>? Tweets { get; set; }  // Many-to-Many ilişkisi için koleksiyon
    }
}
