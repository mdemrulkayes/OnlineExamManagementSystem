using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;

namespace api.oems.Persistence
{
    public class UserWithInstituteRepository : IUserWithInstituteRepository
    {
        private readonly IRepository<UserWithInstitute> _repository;

        public UserWithInstituteRepository(IRepository<UserWithInstitute> repository)
        {
            _repository = repository;
        }

        public void CreateUserWithInstitute(UserWithInstitute userWithInstitute)
        {
            _repository.Create(userWithInstitute);
        }

        public void RemoveUserWithInstitute(UserWithInstitute userWithInstitute)
        {
            _repository.Delete(userWithInstitute);
        }

        public async Task<UserWithInstitute> GetUserWithInstituteAync(string userId, int? instituteId)
        {
            return await _repository.FindAsync(x => x.UserId == userId && x.InstituteId == instituteId);
        }
    }
}
