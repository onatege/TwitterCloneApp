﻿namespace TwitterCloneApp.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isTrending { get; set; }
        public ICollection<Tweet>? Tweets { get; set; }  // Many-to-Many ilişkisi için koleksiyon
    }
}
