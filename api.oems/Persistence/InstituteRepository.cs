using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class InstituteRepository : IInstituteRepository
    {
        private readonly IRepository<Institute> _repository;
        private readonly OemsDbContext _context;

        public InstituteRepository(IRepository<Institute> repository, OemsDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<Institute>> GetInstitutesAsync()
        {
            return await _context.Institutes
                .Include(x => x.User)
                .Include(x => x.Students)
                .Include(x => x.Categories).ToListAsync();
        }

        public async Task<IEnumerable<Institute>> GetInstitutesAsync(string userId)
        {
            return await _context.Institutes
                .Include(x => x.User)
                .Include(x => x.Students)
                .Include(x => x.Categories)
                .Where(x => !x.IsDeleted && x.UserId == userId).ToListAsync();
        }

        public async Task<Institute> GetInstituteAsyncByInstituteId(int? id)
        {
            return await _context.Institutes
                .Include(x => x.User)
                .Include(x => x.Students)
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void CreateInstitute(Institute institute)
        {
            _repository.Create(institute);
        }

        public void DeleteInstitute(Institute institute)
        {
            _repository.Update(institute);
        }

        public void UpdateInstitute(Institute institute)
        {
            _repository.Update(institute);
        }

        public async Task<bool> IsCurrentUserInstitute(int? instituteId, string userId)
        {
            return await _context.Institutes
                .AnyAsync(x => !x.IsDeleted && x.UserId == userId && x.Id == instituteId);
        }
    }
}
