using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TitleRepository : Repository<Title>, ITitleRepository
    {
        public TitleRepository(TitlesContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Title> GetById(int id)
        {
            var titleDetails = await _dbContext.Titles.Include(t => t.StoryLines)
                .Include(t => t.TitleGenres).ThenInclude(t => t.Genre).Include(t => t.Awards)
                .FirstOrDefaultAsync(t => t.TitleId == id);

            if (titleDetails == null) return null;

            return titleDetails;
        }
        public async Task<List<Title>> GetByName(string name)
        {
            return await _dbContext.Titles.Where(t => t.TitleName.Contains(name)).ToListAsync();
        }
    }
}
