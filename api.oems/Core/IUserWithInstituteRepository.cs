using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IUserWithInstituteRepository
    {
        void CreateUserWithInstitute(UserWithInstitute userWithInstitute);

        void RemoveUserWithInstitute(UserWithInstitute userWithInstitute);

        Task<UserWithInstitute> GetUserWithInstituteAync(string userId, int? instituteId);
    }
}
