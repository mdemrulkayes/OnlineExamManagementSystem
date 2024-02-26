using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.Tutor.TutorArea;
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
    public class TutorAreaController : Controller
    {
        private readonly ITutorAreaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TutorAreaController(ITutorAreaRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("{districtId}")]
        public async Task<IActionResult> GetAllAreas(int? districtId)
        {
            try
            {
                if (districtId == null)
                {
                    return BadRequest("Please provide District Id");
                }
                var allDistrict = await _repository.GetAllTutorAreaAsync();

                return Ok(new CustomResponse(){Result = _mapper.Map<IEnumerable<TutorArea>, IEnumerable<TutorAreaResources>>(
                    allDistrict.Where(x => x.DistrictId == districtId)), Message = CustomMessage.FetchInformation("Area")});
            }
            catch (Exception e)
            {
                Log.Error(e, $"Getting error from { Url.Action("GetAllAreas", "TutorArea", Request.Scheme)}");
                return BadRequest(e);
            }
        }

        [HttpGet("{districtId}/{areaId}")]
        public async Task<IActionResult> GetArea(int? districtId, int? areaId)
        {
            try
            {
                if (districtId == null)
                {
                    return BadRequest("Please provide District Id");
                }
                var allDistrict = await _repository.GetAllTutorAreaAsync();

                var areaDetails = _mapper.Map<TutorArea, TutorAreaResources>(
                    allDistrict.FirstOrDefault(x => x.DistrictId == districtId && x.Id == areaId));
                if (areaDetails == null)
                {
                    return NotFound(CustomMessage.NotFoundInformation("Area"));
                }
                return Ok(new CustomResponse()
                {
                    Result = areaDetails,
                    Message = CustomMessage.FetchInformation("Area")
                });
            }
            catch (Exception e)
            {
                Log.Error(e, $"Getting error from { Url.Action("GetAllAreas", "TutorArea", Request.Scheme)}");
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveTutorAreaResources resources)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var allArea = await _repository.GetAllTutorAreaAsync();

                if (allArea.Any(x => x.AreaName.ToLower().Trim() == resources.AreaName.ToLower().Trim()))
                {
                    return BadRequest(CustomMessage.AlreadyExist("Area"));
                }

                var data = _mapper.Map<SaveTutorAreaResources, TutorArea>(resources);
                data.IsActive = true;
                data.IsDeleted = false;
                data.CreatedAt = DateTime.UtcNow;
                data.CreatedBy = User.FindFirst("UserId").Value;

                _repository.Create(data);
                await _unitOfWork.CompleteAsync();

                return Ok(new CustomResponse()
                {
                    Result = data,
                    Message = CustomMessage.CreateInformation("Area")
                });
            }
            catch (Exception e)
            {
                Log.Error(e, $"Getting error from { Url.Action("GetAllAreas", "TutorArea", Request.Scheme)}");
                return BadRequest(e);
            }
        }
    }
}