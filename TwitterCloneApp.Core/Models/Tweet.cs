using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterCloneApp.Core.Models
{
	public class Tweet : BaseEntity
	{
		public int UserId { get; set; }
		public string Content { get; set; }
		public bool isDeleted { get; set; }
		public User User { get; set; }
		public ICollection<Tag> Tags { get; set; }
		public ICollection <TwReply> TwReplies { get; set; }
		public ICollection <Like> Likes { get; set; }
		
	}
}
