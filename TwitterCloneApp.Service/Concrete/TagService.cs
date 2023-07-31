using AutoMapper;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Request.Tag;
using TwitterCloneApp.DTO.Response.Tag;
using TwitterCloneApp.Service.Exceptions;

namespace TwitterCloneApp.Service.Concrete
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITweetRepository _tweetRepository;

        public TagService(ITagRepository tagRepository, IMapper mapper, IUnitOfWork unitOfWork, ITweetRepository tweetRepository)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tweetRepository = tweetRepository;
        }
        public async Task<List<TagDto>> GetAllTagsAsync()
        {
            var tags = await _tagRepository.GetTags();
            var tagDto = _mapper.Map<List<TagDto>>(tags);
            return tagDto;
        }

        public async Task<TagDto> GetTagByIdAsync(int id)
        {
            var tag = await _tagRepository.GetTagByIdAsync(id);
            if (tag == null)
            {
                throw new NotFoundException($"TagId({id}) not found");
            }
			var tagDto = _mapper.Map<TagDto>(tag);
			tagDto.Tweets = await _tweetRepository.GetTagTweetsWithLikeCountAsync(id);
			return tagDto;
			
        }

        public async Task AddTagAsync(AddTagDto addTagDto)
        {
            var tag = _mapper.Map<Tag>(addTagDto);
            await _tagRepository.AddAsync(tag);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveTagAsync(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            _tagRepository.Remove(tag);
            await _unitOfWork.CommitAsync();
        }
    }
}
