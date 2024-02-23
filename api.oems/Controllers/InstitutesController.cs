using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.Institutes;
using api.oems.Core;
using api.oems.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.oems.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class InstitutesController : ControllerBase
    {
        private readonly IInstituteRepository _instituteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstitutesController(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _instituteRepository = instituteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstitute([FromBody] SaveInstituteResources institute)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createInstituteResult = _mapper.Map<SaveInstituteResources, Institute>(institute);
                createInstituteResult.UserId = User.FindFirst("UserId").Value;
                createInstituteResult.CreatedAt = DateTime.UtcNow;
                createInstituteResult.IsApproved = false;
                createInstituteResult.IsRejected = false;

                _instituteRepository.CreateInstitute(createInstituteResult);
                await _unitOfWork.CompleteAsync();
                return Ok(createInstituteResult);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetInstitutes()
        {
            IEnumerable<Institute> instituteList;

            if (User.IsInRole("Developer") || User.IsInRole("SuperAdmin"))
            {
                 instituteList = await _instituteRepository.GetInstitutesAsync(User.FindFirst("UserId").Value);
            }
            else
            {
                instituteList = await _instituteRepository.GetInstitutesAsync(User.FindFirst("UserId").Value);
            }

            return Ok(_mapper.Map<IEnumerable<Institute>, IEnumerable<InstituteResources>>(instituteList));
        }

        [HttpGet]
        public async Task<IActionResult> GetApprovedInstitutes()
        {
            var data = await _instituteRepository.GetInstitutesAsync(User.FindFirst("UserId").Value);
            IEnumerable<Institute> instituteList = data.Where(x => x.IsApproved && !x.IsRejected).ToList();
            return Ok(_mapper.Map<IEnumerable<Institute>, IEnumerable<InstituteResources>>(instituteList));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstitute(int? id)
        {
            var result = await _instituteRepository.GetInstituteAsyncByInstituteId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Institute, InstituteResources>(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstitute(int? id, [FromBody]SaveInstituteResources institute)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id == null)
                {
                    return BadRequest("Id can not be null.");
                }

                var data = await _instituteRepository.GetInstituteAsyncByInstituteId(id);
                var result = _mapper.Map(institute, data);
                result.UpdatedAt = DateTime.UtcNow;

                _instituteRepository.UpdateInstitute(result);
                await _unitOfWork.CompleteAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ApproveInstitute(int? id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id == null)
                {
                    return BadRequest("Id can not be null.");
                }

                var data = await _instituteRepository.GetInstituteAsyncByInstituteId(id);
                data.IsApproved = true;
                data.IsRejected = false;
                _instituteRepository.UpdateInstitute(data);
                await _unitOfWork.CompleteAsync();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> RejectInstitute(int? id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id == null)
                {
                    return BadRequest("Id can not be null.");
                }

                var data = await _instituteRepository.GetInstituteAsyncByInstituteId(id);
                data.IsRejected = true;
                _instituteRepository.UpdateInstitute(data);
                await _unitOfWork.CompleteAsync();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitute(int? id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id == null)
                {
                    return BadRequest("Id can not be null.");
                }

                var data = await _instituteRepository.GetInstituteAsyncByInstituteId(id);
                data.IsDeleted = true;
                _instituteRepository.UpdateInstitute(data);
                await _unitOfWork.CompleteAsync();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }
    }
}