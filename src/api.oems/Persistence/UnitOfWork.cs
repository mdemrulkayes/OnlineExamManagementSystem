using System.Threading.Tasks;
using api.oems.Core;

namespace api.oems.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OemsDbContext _dbContext;

        public UnitOfWork(OemsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
