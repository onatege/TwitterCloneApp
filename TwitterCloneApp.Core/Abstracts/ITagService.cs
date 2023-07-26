using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.DTO.Tag;

namespace TwitterCloneApp.Core.Abstracts
{
    public interface ITagService
    {
        Task<List<TagDto>> GetAllTagsAsync();
        Task<TagDto> GetTagByIdAsync(int id);
        Task AddTagAsync(AddTagDto addTagDto);
        Task RemoveTagAsync(int id);
    }
}
