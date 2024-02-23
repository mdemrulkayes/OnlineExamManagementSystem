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
    public class TutorDistrictRepository: ITutorDistrictRepository
    {
        private readonly IRepository<TutorDistrict> _repository;
        private readonly OemsDbContext _context;

        public TutorDistrictRepository(IRepository<TutorDistrict> repository, OemsDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<TutorDistrict> GetTutorDistrict(int? id)
        {
            try
            {
                return await _context.Districts.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TutorDistrict>> GetAllTutorDistrict()
        {
            try
            {
                return await _context.Districts.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CreateTutorDistrict(TutorDistrict district)
        {
            try
            {
                _repository.Create(district);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void UpdateTutorDistrict(TutorDistrict district)
        {
            try
            {
                _repository.Update(district);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void DeleteTutorDistrict(TutorDistrict district)
        {
            try
            {
                _repository.Delete(district);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
