using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.QuestionSets;
using api.oems.Core;
using api.oems.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.oems.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class QuestionsSetController : ControllerBase
    {
        private readonly IQuestionSetRepository _questionSetRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionOptionsRepository _questionOptionsRepository;

        public QuestionsSetController(IQuestionSetRepository questionSetRepository, IMapper mapper, IUnitOfWork unitOfWork, IQuestionOptionsRepository questionOptionsRepository)
        {
            _questionSetRepository = questionSetRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _questionOptionsRepository = questionOptionsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestionSets()
        {
            return Ok(_mapper.Map<IEnumerable<QuestionSet>, IEnumerable<QuestionSetResources>>(await _questionSetRepository.GetAllQuestionSetsAsync(User.FindFirst("UserId").Value)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionSets(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Invalid Request");
            }

            return Ok(_mapper.Map<QuestionSet, QuestionSetResources>(await _questionSetRepository.GetQuestionSetAsync(id, User.FindFirst("UserId").Value)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestionSet([FromBody] SaveQuestionSetResources resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obj = _mapper.Map<SaveQuestionSetResources, QuestionSet>(resource);
            obj.CreatedBy = User.FindFirst("userId").Value;
            obj.CreatedAt = DateTime.UtcNow;
            obj.UpdatedAt = DateTime.UtcNow;
            obj.UpdatedBy = User.FindFirst("UserId").Value;

            _questionSetRepository.CreateQuestionSet(obj);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionSet(int? id, [FromBody] SaveQuestionSetResources resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == null || id == 0)
            {
                return BadRequest("Invalid request");
            }

            var data = await _questionSetRepository.GetQuestionSetAsync(id, User.FindFirst("UserId").Value);

            if (data == null)
            {
                return BadRequest("No result found");
            }

            var result = _mapper.Map(resources, data);
            result.UpdatedAt = DateTime.UtcNow;
            result.UpdatedBy = User.FindFirst("UserId").Value;

            _questionSetRepository.UpdateQuestionSet(result);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionSet(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Invalid request");
            }

            var data = await _questionSetRepository.GetQuestionSetAsync(id, User.FindFirst("UserId").Value);

            if (data == null)
            {
                return BadRequest("No result found");
            }


            data.IsDeleted = true;
            foreach (var question in data.Questions)
            {
                question.IsDeleted = true;
                question.UpdatedAt = DateTime.UtcNow;
                question.UpdatedBy = User.FindFirst("UserId").Value;

                var questionOptions = await _questionOptionsRepository.GetQuestionOptionsByQuestionIdAsync(question.Id);

                foreach (var options in questionOptions)
                {
                    options.IsDeleted = true;
                    options.UpdatedAt = DateTime.UtcNow;
                    options.UpdatedBy = User.FindFirst("UserId").Value;
                }
            }

            data.UpdatedAt = DateTime.UtcNow;
            data.UpdatedBy = User.FindFirst("UserId").Value;
            _questionSetRepository.UpdateQuestionSet(data);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

    }
}