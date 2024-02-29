using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IMemberShipDetailsRespository
    {
        Task<IEnumerable<MembershipDetail>> GetAllMembershipdetailsAsync();

        Task<MembershipDetail> GetMembershipDetailsById(int? id);

        void CreateMembershipDetails(MembershipDetail details);

        void UpdateMembershipDetails(MembershipDetail details);

        void DeleteMembershipDetails(MembershipDetail details);
    }
}
