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

        public async Task<List<Tag>> GetAllTags()
        {
            return await _tag.Include(u => u.Tweets).ToListAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _tag.FindAsync(id);
            
        }
    }
}
