using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IInstituteRepository
    {
        Task<IEnumerable<Institute>> GetInstitutesAsync();

        Task<IEnumerable<Institute>> GetInstitutesAsync(string userId);

        Task<Institute> GetInstituteAsyncByInstituteId(int? id);

        void CreateInstitute(Institute institute);

        void DeleteInstitute(Institute institute);

        void UpdateInstitute(Institute institute);

        Task<bool> IsCurrentUserInstitute(int? instituteId, string userId);
    }
}
