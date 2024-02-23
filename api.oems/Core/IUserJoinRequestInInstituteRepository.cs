using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IUserJoinRequestInInstituteRepository
    {
        void CreateUserJoinRequest(UserInstituteJoinRequest request);

        void UpdateUserJoinRequest(UserInstituteJoinRequest request);

        void CancelUserJoinRequest(UserInstituteJoinRequest request);

        Task<IEnumerable<UserInstituteJoinRequest>> GetUserJoinRequestsAsync();

        Task<IEnumerable<UserInstituteJoinRequest>> GetUserJoinRequestsAsync(int? instituteId);

        Task<IEnumerable<UserInstituteJoinRequest>> GetUserJoinRequestsAsync(string userId);

        Task<UserInstituteJoinRequest> GetUserJoinRequestByIdAsync(int? id);
    }
}
