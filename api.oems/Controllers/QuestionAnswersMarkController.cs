using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.QuestionAnswers;
using api.oems.Core;
using api.oems.Core.Enum;
using api.oems.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.oems.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuestionAnswersMarkController : ControllerBase
    {
        private readonly IQuestionAnswersMarkRepository _questionAnswersMarkRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionAnswersMarkController(IQuestionAnswersMarkRepository questionAnswersMarkRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _questionAnswersMarkRepository = questionAnswersMarkRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestionAnswersMark()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<QuestionAnswersMark>, IEnumerable<QuestionAnswersMarkResources>>(await _questionAnswersMarkRepository.GetAllQuestionAnswersMarkAsync(User.FindFirst("UserId").Value)));
            }
            catch (Exception)
            {
                return BadRequest(ServerRequestMessage.DataNotFound);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionAnswersMark(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return BadRequest(ServerRequestMessage.InvalidRequest);
                }

                return Ok(_mapper.Map<QuestionAnswersMark, QuestionAnswersMarkResources>(await _questionAnswersMarkRepository.GetQuestionAnswersMarkAsync(id, User.FindFirst("UserId").Value)));
            }
            catch (Exception)
            {
                return BadRequest(ServerRequestMessage.DataNotFound);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestionAnswersMark([FromBody] SaveQuestionAnswersMarkResources resource)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var obj = _mapper.Map<SaveQuestionAnswersMarkResources, QuestionAnswersMark>(resource);
                obj.CreatedBy = User.FindFirst("userId").Value;
                obj.CreatedAt = DateTime.UtcNow;

                _questionAnswersMarkRepository.CreateQuestionAnswersMark(obj);
                await _unitOfWork.CompleteAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(ServerRequestMessage.DataNotFound);
            }
        }
    }
}