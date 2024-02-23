using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
