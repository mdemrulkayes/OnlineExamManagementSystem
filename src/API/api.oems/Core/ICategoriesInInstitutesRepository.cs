using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface ICategoriesInInstitutesRepository
    {
        void Create(CategoriesInInstitute categoriesInInstitute);

        void Update(CategoriesInInstitute categoriesInInstitute);

        void Delete(CategoriesInInstitute categoriesInInstitute);
    }
}
