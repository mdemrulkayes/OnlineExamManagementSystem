using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly IRepository<Chapter> _repository;
        private readonly OemsDbContext _context;

        public ChapterRepository(OemsDbContext context, IRepository<Chapter> repository)
        {
            _context = context;
            _repository = repository;
        }

        public void CreateChapter(Chapter chapter)
        {
            _repository.Create(chapter);
        }

        public void UpdateChapter(Chapter chapter)
        {
            _repository.Update(chapter);
        }

        public void DeleteChapter(Chapter chapter)
        {
            _repository.Delete(chapter);
        }

        public async Task<IEnumerable<Chapter>> GetChaptersAsync()
        {
            return await _context.Chapters.Include(x => x.Subject).Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Chapter>> GetChaptersAsync(string userId)
        {
            return await _context.Chapters.Include(x => x.Subject)
                .Where(x => !x.IsDeleted && x.Subject.Category.Institutes.Any(y => y.Institute.UserId == userId)).ToListAsync();
        }

        public async Task<Chapter> GetChapterAsync(int? id)
        {
            return await _context.Chapters.Include(x => x.Subject).FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
        }

        public async Task<Chapter> GetChapterAsync(string chapterCode)
        {
            return await _context.Chapters.Include(x => x.Subject).FirstOrDefaultAsync(x => !x.IsDeleted && x.ChapterCode == chapterCode);
        }
    }
}
