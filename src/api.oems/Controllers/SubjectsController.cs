using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.Subjects;
using api.oems.Core;
using api.oems.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.oems.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            return Ok(_mapper.Map<IEnumerable<Subject>,IEnumerable<SubjectResources>>
                (await _subjectRepository.GetAllSubjectsAsync(User.FindFirst("UserId").Value)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjects(int? id)
        {
            return Ok(_mapper.Map<Subject, SubjectResources>(await _subjectRepository.GetSubjectById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody]SaveSubjectResources subject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = _mapper.Map<SaveSubjectResources, Subject>(subject);
                data.CreatedBy = User.FindFirst("UserId").Value;
                data.CreatedDate = DateTime.UtcNow;
                data.UpdatedBy = User.FindFirst("UserId").Value;
                data.UpdatedDate = DateTime.UtcNow;
                data.IsDeleted = false;

                _subjectRepository.CreateSubject(data);
                await _unitOfWork.CompleteAsync();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int? id,[FromBody] SaveSubjectResources subject)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Id Can not be empty");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _subjectRepository.GetSubjectById(id);

                var data = _mapper.Map(subject,result);
                data.UpdatedBy = User.FindFirst("UserId").Value;
                data.UpdatedDate = DateTime.UtcNow;

                _subjectRepository.UpdateSubject(data);
                await _unitOfWork.CompleteAsync();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Id Can not be empty");
                }

                var result = await _subjectRepository.GetSubjectById(id);
                result.IsDeleted = true;

                _subjectRepository.UpdateSubject(result);
                await _unitOfWork.CompleteAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}