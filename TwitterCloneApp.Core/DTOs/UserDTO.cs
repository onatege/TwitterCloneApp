using System;
namespace TwitterCloneApp.Core.DTOs
{
	public class UserDTO
	{
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Biography { get; set; }
        public string? ProfileImg { get; set; }
    }
}

