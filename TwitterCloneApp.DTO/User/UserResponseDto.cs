namespace TwitterCloneApp.DTO.User
{
	public class UserResponseDto : IBaseDto
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string ProfileImg { get; set; }
    }
}
