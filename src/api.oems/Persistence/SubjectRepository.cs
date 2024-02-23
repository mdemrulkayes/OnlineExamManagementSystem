using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IRepository<Subject> _repository;
        private readonly OemsDbContext _context;

        public SubjectRepository(IRepository<Subject> repository, OemsDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void CreateSubject(Subject subject)
        {
            _repository.Create(subject);
        }

        public void UpdateSubject(Subject subject)
        {
            _repository.Update(subject);
        }

        public void DeleteSubejct(Subject subject)
        {
            _repository.Delete(subject);
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.Include(x => x.Category).Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync(string userId)
        {
            return await _context.Subjects.Include(x => x.Category)
                .Where(x => !x.IsDeleted && 
                            x.Category.Institutes.Any(y => y.Institute.UserId == userId)).ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int? id)
        {
            return await _context.Subjects.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Subject> GetSubjectByCode(string subjectCode)
        {
            return await _context.Subjects.Include(x => x.Category).FirstOrDefaultAsync(x => x.SubjectCode == subjectCode);
        }
    }
}
