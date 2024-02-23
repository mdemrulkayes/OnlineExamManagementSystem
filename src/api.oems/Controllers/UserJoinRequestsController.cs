using System;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.UserJoinRequest;
using api.oems.Core;
using api.oems.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.oems.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class UserJoinRequestsController : ControllerBase
    {
        private readonly IUserJoinRequestInInstituteRepository _userJoinRequestInInstituteRepository;
        private readonly IInstituteRepository _instituteRepository;
        private readonly IUserWithInstituteRepository _userWithInstituteRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserJoinRequestsController(IUserJoinRequestInInstituteRepository userJoinRequestInInstituteRepository, IUnitOfWork unitOfWork, IMapper mapper, IInstituteRepository instituteRepository, IUserWithInstituteRepository userWithInstituteRepository)
        {
            _userJoinRequestInInstituteRepository = userJoinRequestInInstituteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _instituteRepository = instituteRepository;
            _userWithInstituteRepository = userWithInstituteRepository;
        }

        [HttpGet]
        //[Authorize(Roles = "Developer")]
        public async Task<IActionResult> GetUserJoinRequests()
        {
            return Ok(await _userJoinRequestInInstituteRepository.GetUserJoinRequestsAsync(User.FindFirst("UserId").Value));
        }

        [HttpGet("{instituteId}")]
        //[Authorize(Roles = "Owner")]
        public async Task<IActionResult> GetUserJoinRequests(int? instituteId)
        {
            if (instituteId == null || instituteId == 0)
            {
                return BadRequest("Invalid Operation");
            }

            if (await _instituteRepository.IsCurrentUserInstitute(instituteId, User.FindFirst("UserId").Value))
            {
                return Ok(await _userJoinRequestInInstituteRepository.GetUserJoinRequestsAsync(instituteId));
            }
            else
            {
                return BadRequest("Invalid Operation");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveUserInstituteJoinRequestResources resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var instituteInfo = await _instituteRepository.GetInstituteAsyncByInstituteId(resources.InstituteId);

            if (instituteInfo == null)
            {
                return BadRequest("Invalid Institute");
            }

            var userId = User.FindFirst("UserId").Value;

            if (await _userWithInstituteRepository.GetUserWithInstituteAync(userId, instituteInfo.Id) != null)
            {
                return BadRequest("User Already in Institute");
            }

            var data = _mapper.Map<SaveUserInstituteJoinRequestResources, UserInstituteJoinRequest>(resources);
            data.UserId = userId;
            data.IsRequestApproved = false;
            data.IsRequestCanceled = false;
            data.IsInstituteLeft = false;
            data.JoinRequestAt = DateTime.UtcNow;

            _userJoinRequestInInstituteRepository.CreateUserJoinRequest(data);
            await _unitOfWork.CompleteAsync();

            return Ok(data);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Developer,Owner")]
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Please enter ID");
            }

            var data = await _userJoinRequestInInstituteRepository.GetUserJoinRequestByIdAsync(id);

            if (data.IsRequestRejected || data.IsRequestCanceled || data.IsInstituteLeft)
            {
                return BadRequest("Invalid Operation");
            }

            data.IsRequestApproved = true;

            _userJoinRequestInInstituteRepository.UpdateUserJoinRequest(data);
            await _unitOfWork.CompleteAsync();

            var userWithInstitute = new UserWithInstitute()
            {
                UserId = data.UserId,
                InstituteId = data.InstituteId
            };

            _userWithInstituteRepository.CreateUserWithInstitute(userWithInstitute);
            await _unitOfWork.CompleteAsync();

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Please enter ID");
            }

            var data = await _userJoinRequestInInstituteRepository.GetUserJoinRequestByIdAsync(id);

            if (data.UserId != User.FindFirst("UserId").Value || data.IsRequestApproved || data.IsRequestRejected)
            {
                return BadRequest("Invalid Request");
            }

            data.IsRequestCanceled = true;

            _userJoinRequestInInstituteRepository.UpdateUserJoinRequest(data);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Left(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Please enter ID");
            }

            var data = await _userJoinRequestInInstituteRepository.GetUserJoinRequestByIdAsync(id);

            if (data.UserId != User.FindFirst("UserId").Value || data.IsRequestCanceled || data.IsRequestRejected)
            {
                return BadRequest("Invalid Request");
            }

            data.IsInstituteLeft = true;

            _userJoinRequestInInstituteRepository.UpdateUserJoinRequest(data);
            await _unitOfWork.CompleteAsync();

            var userInInstitute =
                await _userWithInstituteRepository.GetUserWithInstituteAync(data.UserId, data.InstituteId);

            _userWithInstituteRepository.RemoveUserWithInstitute(userInInstitute);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Developer,Owner")]
        public async Task<IActionResult> Reject(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Please enter ID");
            }

            var data = await _userJoinRequestInInstituteRepository.GetUserJoinRequestByIdAsync(id);

            data.IsRequestRejected = true;

            _userJoinRequestInInstituteRepository.UpdateUserJoinRequest(data);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}