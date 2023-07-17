using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterCloneApp.Core.Models
{
	public class Like 
	{
		public int TweetId { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public Tweet Tweet { get; set; }

	}
}
