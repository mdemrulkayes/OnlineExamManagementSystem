using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IChapterRepository
    {
        void CreateChapter(Chapter chapter);

        void UpdateChapter(Chapter chapter);

        void DeleteChapter(Chapter chapter);

        Task<IEnumerable<Chapter>> GetChaptersAsync();

        Task<IEnumerable<Chapter>> GetChaptersAsync(string userId);

        Task<Chapter> GetChapterAsync(int? id);

        Task<Chapter> GetChapterAsync(string chapterCode);
    }
}
