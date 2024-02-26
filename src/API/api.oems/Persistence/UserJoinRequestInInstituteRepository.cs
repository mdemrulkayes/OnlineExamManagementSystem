using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class UserJoinRequestInInstituteRepository : IUserJoinRequestInInstituteRepository
    {
        private readonly IRepository<UserInstituteJoinRequest> _repository;
        private readonly OemsDbContext _context;

        public UserJoinRequestInInstituteRepository(OemsDbContext context, IRepository<UserInstituteJoinRequest> repository)
        {
            _context = context;
            _repository = repository;
        }

        public void CreateUserJoinRequest(UserInstituteJoinRequest request)
        {
            _repository.Create(request);
        }

        public void UpdateUserJoinRequest(UserInstituteJoinRequest request)
        {
            _repository.Update(request);
        }

        public void CancelUserJoinRequest(UserInstituteJoinRequest request)
        {
            _repository.Update(request);
        }

        public async Task<IEnumerable<UserInstituteJoinRequest>> GetUserJoinRequestsAsync()
        {
            return await _context.UserInstituteJoinRequests
                .Include(x => x.Institute)
                .Include(x => x.StudentUser)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserInstituteJoinRequest>> GetUserJoinRequestsAsync(int? instituteId)
        {
            return await _context.UserInstituteJoinRequests
                .Include(x => x.Institute)
                .Include(x => x.StudentUser)
                .Where(x => x.InstituteId == instituteId && !x.IsInstituteLeft && !x.IsRequestApproved 
                            && !x.IsRequestCanceled && !x.IsRequestRejected)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserInstituteJoinRequest>> GetUserJoinRequestsAsync(string userId)
        {
            return await _context.UserInstituteJoinRequests
                .Include(x => x.Institute)
                .Include(x => x.StudentUser)
                .Where(x => !x.IsInstituteLeft && !x.IsRequestApproved
                            && !x.IsRequestCanceled && !x.IsRequestRejected && x.Institute.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserInstituteJoinRequest> GetUserJoinRequestByIdAsync(int? id)
        {
            return await _context.UserInstituteJoinRequests
                .Include(x => x.Institute)
                .Include(x => x.StudentUser)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
