using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;

namespace api.oems.Persistence
{
    public class CategoriesInInstitutesRepository : ICategoriesInInstitutesRepository
    {
        private readonly IRepository<CategoriesInInstitute> _repository;

        public CategoriesInInstitutesRepository(IRepository<CategoriesInInstitute> repository)
        {
            _repository = repository;
        }

        public void Create(CategoriesInInstitute categoriesInInstitute)
        {
            _repository.Create(categoriesInInstitute);
        }

        public void Update(CategoriesInInstitute categoriesInInstitute)
        {
            _repository.Update(categoriesInInstitute);
        }

        public void Delete(CategoriesInInstitute categoriesInInstitute)
        {
            _repository.Delete(categoriesInInstitute);
        }
    }
}
