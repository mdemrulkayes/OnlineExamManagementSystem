using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.Questions;
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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionsController(IQuestionRepository questionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{questionSetId}")]
        public async Task<IActionResult> GetQuestions(int? questionSetId)
        {
            return Ok(_mapper.Map<IEnumerable<Question>,IEnumerable <QuestionResources>>(await _questionRepository.GetQuestionsAsync(questionSetId)));
        }

        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetQuestion(int? questionId)
        {
            return Ok(_mapper.Map<Question, QuestionResources>(await _questionRepository.GetQuestionAsync(questionId)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody]SaveQuestionResources[] resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foreach (var data in resources)
            {
                var obj = _mapper.Map<SaveQuestionResources, Question>(data);

                _questionRepository.CreateQuestion(obj);
            }
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("{questionId}")]
        public async Task<IActionResult> UpdateQuestion(int? questionId, [FromBody] SaveQuestionResources resources)
        {
            if (questionId == null || questionId == 0)
            {
                return BadRequest("Invalid Request");
            }

            var data = await _questionRepository.GetQuestionAsync(questionId);
            if (data == null)
            {
                return BadRequest("Invalid Request");
            }

            var res = _mapper.Map(resources, data);
            res.UpdatedAt = DateTime.UtcNow;
            res.UpdatedBy = User.FindFirst("UserId").Value;
            
            _questionRepository.UpdateQuestion(res);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("{questionId}")]
        public async Task<IActionResult> DeleteQuestion(int? questionId)
        {
            if (questionId == null || questionId == 0)
            {
                return BadRequest("Invalid Request");
            }

            var data = await _questionRepository.GetQuestionAsync(questionId);
            if (data == null)
            {
                return BadRequest("Invalid Request");
            }

            data.IsDeleted = true;
            data.UpdatedAt = DateTime.UtcNow;
            data.UpdatedBy = User.FindFirst("UserId").Value;

            foreach (var questionOption in data.QuestionOptions)
            {
                questionOption.IsDeleted = true;
                questionOption.UpdatedAt = DateTime.UtcNow;
                questionOption.UpdatedBy = User.FindFirst("UserId").Value;
            }

            _questionRepository.UpdateQuestion(data);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}