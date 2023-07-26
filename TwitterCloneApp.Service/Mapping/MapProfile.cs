using AutoMapper;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.Tweet;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // User DTO mappings
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AddUserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();
            CreateMap<UserNameDto, User>().ReverseMap();
            CreateMap<DeleteDto, User>().ReverseMap();
            CreateMap<User,GetUserProfileDto> ().ReverseMap();
            CreateMap<AddTweetDto, Tweet>().ReverseMap();
            CreateMap<TweetDto, Tweet>().ReverseMap();
            CreateMap<Tweet,UpdateTweetDto>().ReverseMap();
        }
    }
}
