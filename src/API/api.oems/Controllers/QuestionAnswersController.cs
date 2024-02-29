using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.QuestionAnswers;
using api.oems.Core;
using api.oems.Core.Enum;
using api.oems.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.oems.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class QuestionAnswersController : ControllerBase
    {
        private readonly IQuestionAnswersRepository _questionAnswersRepository;
        private readonly IQuestionSetRepository _questionSetRepository;
        private readonly IQuestionAnswersMarkRepository _questionAnswersMarkRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionAnswersController(IQuestionAnswersRepository questionAnswersRepository, IMapper mapper, IUnitOfWork unitOfWork, IQuestionSetRepository questionSetRepository, IQuestionAnswersMarkRepository questionAnswersMarkRepository)
        {
            _questionAnswersRepository = questionAnswersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _questionSetRepository = questionSetRepository;
            _questionAnswersMarkRepository = questionAnswersMarkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestionAnswers()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<QuestionAnswers>, IEnumerable<QuestionAnswersResources>>(await _questionAnswersRepository.GetAllQuestionAnswersAsync(User.FindFirst("UserId").Value)));
            }
            catch (Exception)
            {
                return BadRequest(ServerRequestMessage.DataNotFound);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionAnswers(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return BadRequest(ServerRequestMessage.InvalidRequest);
                }

                return Ok(_mapper.Map<QuestionAnswers, QuestionAnswersResources>(await _questionAnswersRepository.GetQuestionAnswersAsync(id, User.FindFirst("UserId").Value)));
            }
            catch (Exception)
            {
                return BadRequest(ServerRequestMessage.DataNotFound);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestionAnswers([FromBody] SaveQuestionAnswersResources[] resources)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                DateTime examDateTime = DateTime.UtcNow;
                var questionSet = await _questionSetRepository.GetQuestionSetAsync(resources[0].QuestionSetId, User.FindFirst("UserId").Value);
                QuestionAnswersMark questionAnswersMarkModel = new QuestionAnswersMark();
                questionAnswersMarkModel.UserId = User.FindFirst("userId").Value;
                questionAnswersMarkModel.FullMark = questionSet.FullMark;
                questionAnswersMarkModel.PassedMark = questionSet.PassedMark;
                _questionAnswersMarkRepository.CreateQuestionAnswersMark(questionAnswersMarkModel);
                var questionAnswersMark = 0;

                foreach (var resource in resources)
                {
                    var obj = _mapper.Map<SaveQuestionAnswersResources, QuestionAnswers>(resource);
                    obj.CreatedBy = User.FindFirst("userId").Value;
                    obj.CreatedAt = DateTime.UtcNow;
                    obj.ExamDateTime = examDateTime;
                    obj.QuestionAnswersMarkId = questionAnswersMark;

                    _questionAnswersRepository.CreateQuestionAnswers(obj);
                }

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