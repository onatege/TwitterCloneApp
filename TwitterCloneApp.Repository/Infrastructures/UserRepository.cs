using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public async Task<GetUserProfileDto> GetUserByUsernameAsync(UsernameDto getByUsernameDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName.Equals(getByUsernameDto.UserName));
            return _mapper.Map<GetUserProfileDto>(user);
        }

        public async Task<UserDto> AddUserAsync(AddUserDto addUserDto)
        {
            var user = _mapper.Map<User>(addUserDto);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task SoftDeleteUserAsync(DeleteDto deleteDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == deleteDto.UserName);
            if (user != null)
            {
                user.IsDeleted = true;
                user.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == updateUserDto.UserName);
            if (user != null)
            {
                user.DisplayName = updateUserDto.DisplayName;
                user.Email = updateUserDto.Email;
                user.Biography = updateUserDto.Biography;
                user.ProfileImg = updateUserDto.ProfileImg;
                await _context.SaveChangesAsync();
            }
        }
    }
}
