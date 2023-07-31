using TwitterCloneApp.DTO.Request.Tag;
using TwitterCloneApp.DTO.Response.Tag;

namespace TwitterCloneApp.Core.Abstracts
{
    public interface ITagService
    {
        Task<List<TagDto>> GetAllTagsAsync();
        Task<TagDto> GetTagByIdAsync(int id);
        Task<List<TrendingTagsResponseDto>> GetTrendingTagsAsync();
        Task AddTagAsync(AddTagDto addTagDto);
        Task RemoveTagAsync(int id);
    }
}
