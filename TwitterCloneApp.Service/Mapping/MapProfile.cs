using AutoMapper;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Request.Tag;
using TwitterCloneApp.DTO.Request.Tweet;
using TwitterCloneApp.DTO.Request.User;
using TwitterCloneApp.DTO.Response.Reply;
using TwitterCloneApp.DTO.Response.Tag;
using TwitterCloneApp.DTO.Response.Tweet;
using TwitterCloneApp.DTO.Response.User;

namespace TwitterCloneApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AddUserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();
            CreateMap<DeleteDto, User>().ReverseMap();
            CreateMap<User, GetUserProfileDto> ().ReverseMap();
            CreateMap<User, UserResponseDto> ().ReverseMap();
            CreateMap<AddTweetDto, Tweet>().ReverseMap();
            CreateMap<TweetDto, Tweet>().ReverseMap();
            CreateMap<Tweet, UpdateTweetDto>().ReverseMap();
            CreateMap<Tweet, ReplyResponseDto>().ReverseMap();
            CreateMap<Tag, TagResponseDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, AddTagDto>().ReverseMap();
            CreateMap<Like, LikeTweetDto>().ReverseMap();
        }
    }
}
