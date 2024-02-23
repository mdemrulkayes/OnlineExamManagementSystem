using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.Tutor.District;
using api.oems.Core;
using api.oems.Core.Models.Tutor;
using api.oems.Core.Tutor;
using AutoMapper;
using common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace api.oems.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [Authorize]
    public class TutorDistrictController : Controller
    {
        private readonly ITutorDistrictRepository _tutorDistrictRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TutorDistrictController(IUnitOfWork unitOfWork, IMapper mapper, ITutorDistrictRepository tutorDistrictRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tutorDistrictRepository = tutorDistrictRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTutorDistricts()
        {
            try
            {
                return Ok(new CustomResponse()
                {
                    Result = _mapper.Map<IEnumerable<TutorDistrict>, IEnumerable<TutorDistrictResources>>
                (await _tutorDistrictRepository.GetAllTutorDistrict()),
                    Message = CustomMessage.FetchInformation("District")
                });
            }
            catch (Exception e)
            {
                Log.Error(e, $"Getting error from { Url.Action("GetTutorDistricts", "TutorDistrict", Request.Scheme)}");
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTutorDistrict(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NoContent();
                }

                return Ok(new CustomResponse()
                {
                    Result = _mapper.Map<TutorDistrict, TutorDistrictResources>(
                    await _tutorDistrictRepository.GetTutorDistrict(id)),
                    Message = CustomMessage.FetchInformation("District")
                });
            }
            catch (Exception e)
            {
                Log.Error(e, $"Getting error from { Url.Action("GetTutorDistrict", "TutorDistrict", Request.Scheme)}");
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTutorDistrict([FromBody] SaveTutorDistrictResources resources)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var allDistrict = await _tutorDistrictRepository.GetAllTutorDistrict();

                if (allDistrict.Any(x =>
                    x.DistrictName.ToLower().Trim() == resources.DistrictName.ToLower().Trim()))
                {
                    return BadRequest(CustomMessage.AlreadyExist("District"));
                }

                var data = _mapper.Map<SaveTutorDistrictResources, TutorDistrict>(resources);
                data.IsActive = true;
                data.IsDeleted = false;
                data.CreatedAt = DateTime.UtcNow;
                data.CreatedBy = User.FindFirst("UserId").Value;

                _tutorDistrictRepository.CreateTutorDistrict(data);
                await _unitOfWork.CompleteAsync();

                return Ok(new CustomResponse() { Result = data, Message = CustomMessage.CreateInformation("District") });
            }
            catch (Exception e)
            {
                Log.Error(e, $"Getting error from { Url.Action("CreateTutorDistrict", "TutorDistrict", Request.Scheme)}");
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTutorDistrictBulk([FromBody] SaveTutorDistrictResources[] resources)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var allDistrict = await _tutorDistrictRepository.GetAllTutorDistrict();

                foreach (var saveTutorDistrictResourcese in resources)
                {
                    if (allDistrict.Any(x =>
                        x.DistrictName.ToLower().Trim() == saveTutorDistrictResourcese.DistrictName.ToLower().Trim()))
                        continue;
                    var data = _mapper.Map<SaveTutorDistrictResources, TutorDistrict>(saveTutorDistrictResourcese);
                    data.IsActive = true;
                    data.IsDeleted = false;
                    data.CreatedAt = DateTime.UtcNow;
                    data.CreatedBy = User.FindFirst("UserId").Value;

                    _tutorDistrictRepository.CreateTutorDistrict(data);
                }

                await _unitOfWork.CompleteAsync();

                return Ok(new CustomResponse() { Message = CustomMessage.BulkOperationInformation("District") });
            }
            catch (Exception e)
            {
                Log.Error(e, $"Getting error from { Url.Action("CreateTutorDistrict", "TutorDistrict", Request.Scheme)}");
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTutorDistrict(int? id, [FromBody] SaveTutorDistrictResources resources)
        {
            try
            {
                if (id == null)
                {
                    return NoContent();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var allDistrict = await _tutorDistrictRepository.GetAllTutorDistrict();

                if (allDistrict.Any(x =>
                    x.DistrictName.ToLower().Trim() == resources.DistrictName.ToLower().Trim() && x.Id != id))
                {
                    return BadRequest(CustomMessage.AlreadyExist("District"));
                }

                var oldData = await _tutorDistrictRepository.GetTutorDistrict(id);

                if (oldData == null)
                {
                    return NotFound(CustomMessage.NotFoundInformation("District"));
                }

                var data = _mapper.Map(resources, oldData);
                data.IsActive = true;
                data.IsDeleted = false;
                data.UpdatedAt = DateTime.UtcNow;
                data.UpdatedBy = User.FindFirst("UserId").Value;

                _tutorDistrictRepository.UpdateTutorDistrict(data);
                await _unitOfWork.CompleteAsync();

                return Ok(new CustomResponse() { Result = data, Message = CustomMessage.UpdateInformation("District") });
            }
            catch (Exception e)
            {
                Log.Error(e, $"Getting error from { Url.Action("CreateTutorDistrict", "TutorDistrict", Request.Scheme)}");
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutorDistrict(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NoContent();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = await _tutorDistrictRepository.GetTutorDistrict(id);

                if (data == null)
                {
                    return NotFound(CustomMessage.NotFoundInformation("District"));
                }

                data.IsActive = true;
                data.IsDeleted = true;
                data.DeletedAt = DateTime.UtcNow;
                data.DeletedBy = User.FindFirst("UserId").Value;

                _tutorDistrictRepository.UpdateTutorDistrict(data);
                await _unitOfWork.CompleteAsync();

                return Ok(new CustomResponse(){Message = CustomMessage.DeleteInformation("District")});
            }
            catch (Exception e)
            {
                Log.Error(e, $"Getting error from { Url.Action("CreateTutorDistrict", "TutorDistrict", Request.Scheme)}");
                return BadRequest(e);
            }
        }
    }
}