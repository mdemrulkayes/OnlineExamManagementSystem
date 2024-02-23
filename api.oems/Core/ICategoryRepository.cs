using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        Task<Category> GetCategoryByIdAsync(int? id);

        Task<IEnumerable<Category>> GetAllCategoryAsync();

        Task<IEnumerable<Category>> GetAllCategoryAsync(string userId);
    }
}
