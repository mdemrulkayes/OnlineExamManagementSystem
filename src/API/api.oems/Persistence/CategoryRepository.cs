using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Category> _repository;
        private readonly OemsDbContext _context;

        public CategoryRepository(IRepository<Category> repository, OemsDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void CreateCategory(Category category)
        {
            _repository.Create(category);
        }

        public void UpdateCategory(Category category)
        {
            _repository.Update(category);
        }

        public async Task<Category> GetCategoryByIdAsync(int? id)
        {
            return await _context.Categories.Include(x => x.Institutes).FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories.Include(x => x.Institutes).Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync(string userId)
        {
            try
            {
                var data = await _context.Categories.Include(x => x.Institutes)
                    .Where(x => !x.IsDeleted && x.Institutes.Any(y => y.Institute.UserId == userId)).ToListAsync();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }  
        }
    }
}
