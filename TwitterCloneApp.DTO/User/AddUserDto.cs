﻿namespace TwitterCloneApp.DTO
{
    public class AddUserDto
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Biography { get; set; }
        public string? ProfileImg { get; set; }
    }
}
