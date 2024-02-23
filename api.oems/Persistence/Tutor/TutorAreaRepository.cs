using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models.Tutor;
using api.oems.Core.Tutor;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence.Tutor
{
    public class TutorAreaRepository: ITutorAreaRepository
    {
        private readonly IRepository<TutorArea> _repository;
        private readonly OemsDbContext _context;

        public TutorAreaRepository(IRepository<TutorArea> repository, OemsDbContext context)
        {
            _repository = repository;
            _context = context;
        }
        public void Create(TutorArea area)
        {
            _repository.Create(area);
        }

        public void Update(TutorArea area)
        {
            _repository.Update(area);
        }

        public void Delete(TutorArea area)
        {
            _repository.Delete(area);
        }

        public async Task<TutorArea> GetTutorAreaAsync(int? id)
        {
            return await _context.Areas.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
        }

        public async Task<IEnumerable<TutorArea>> GetAllTutorAreaAsync()
        {
            return await _context.Areas.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
        }
    }
}
