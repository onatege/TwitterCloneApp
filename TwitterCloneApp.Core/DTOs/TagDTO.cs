using System;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Core.DTOs
{
	public class TagDTO
	{
        // Id, Name
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
    }
}

