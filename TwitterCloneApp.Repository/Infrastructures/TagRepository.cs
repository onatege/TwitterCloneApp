using Microsoft.EntityFrameworkCore;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Infrastructures
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        private readonly DbSet<Tag> _tag;
        public TagRepository(AppDbContext context) : base(context)
        {
            _tag = context.Set<Tag>();
        }

        public async Task<List<Tag>> GetTags()
        {
            return await _tag.ToListAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _tag.FindAsync(id);
            
        }
    }
}
