using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Core.Abstracts
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Task<List<Tag>> GetTags();
        Task<Tag> GetTagByIdAsync(int id);
    }
}
