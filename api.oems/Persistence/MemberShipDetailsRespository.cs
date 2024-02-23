using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;

namespace api.oems.Persistence
{
    public class MemberShipDetailsRespository : IMemberShipDetailsRespository
    {
        private readonly IRepository<MembershipDetail> _repository;

        public MemberShipDetailsRespository(IRepository<MembershipDetail> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MembershipDetail>> GetAllMembershipdetailsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<MembershipDetail> GetMembershipDetailsById(int? id)
        {
            return await _repository.FindAsync(x => x.Id == id);
        }

        public void CreateMembershipDetails(MembershipDetail details)
        {
            _repository.Create(details);
        }

        public void UpdateMembershipDetails(MembershipDetail details)
        {
            _repository.Update(details);
        }

        public void DeleteMembershipDetails(MembershipDetail details)
        {
            _repository.Delete(details);
        }
    }
}
