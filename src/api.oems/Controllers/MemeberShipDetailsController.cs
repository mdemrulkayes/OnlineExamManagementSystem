using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.MemberShip;
using api.oems.Core;
using api.oems.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.oems.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberShipDetailsController : ControllerBase
    {
        private readonly IMemberShipDetailsRespository _memberShipDetailsRespository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MemberShipDetailsController(IMapper mapper, IMemberShipDetailsRespository memberShipDetailsRespository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memberShipDetailsRespository = memberShipDetailsRespository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _memberShipDetailsRespository.GetAllMembershipdetailsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembershipDetails(int? id)
        {
            return Ok(await _memberShipDetailsRespository.GetMembershipDetailsById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMemebershipDetails([FromBody]SaveMembershipDetailsResources resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var membershipDetails = _mapper.Map<SaveMembershipDetailsResources, MembershipDetail>(resources);
            membershipDetails.CreatedBy = User.FindFirst("Id").Value;

            _memberShipDetailsRespository.CreateMembershipDetails(membershipDetails);
            await _unitOfWork.CompleteAsync();

            return Ok(membershipDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatememebershipDetails(int? id, [FromBody] SaveMembershipDetailsResources resources)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var data = await _memberShipDetailsRespository.GetMembershipDetailsById(id);
            var obj = _mapper.Map(resources, data);

            _memberShipDetailsRespository.UpdateMembershipDetails(obj);
            await _unitOfWork.CompleteAsync();

            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var data = await _memberShipDetailsRespository.GetMembershipDetailsById(id);
            if (data == null)
            {
                return NoContent();
            }

            _memberShipDetailsRespository.DeleteMembershipDetails(data);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

    }
}