using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterCloneApp.DTO.User
{
	public class UserReplyDto
	{
        public UsernameDto UserName { get; set; }
		public string DisplayName { get; set; }
		public string? ProfileImg { get; set; }
		public DateTime CreatedAt { get; set; }
		public LikeDto Likes { get; set; }
    }
}
