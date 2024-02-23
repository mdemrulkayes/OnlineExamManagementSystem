using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.Chapters;
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
    public class ChaptersController : ControllerBase
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChaptersController(IChapterRepository chapterRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetChapters()
        {
            return Ok(_mapper.Map<IEnumerable<Chapter>, IEnumerable<ChapterResources>>(
                await _chapterRepository.GetChaptersAsync(User.FindFirst("UserId").Value)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChapter(int? id)
        {
            return Ok(_mapper.Map<Chapter, ChapterResources>(await _chapterRepository.GetChapterAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateChapter([FromBody] SaveChapterResources resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chapter = _mapper.Map<SaveChapterResources,Chapter>(resources);
            chapter.CreatedAt = DateTime.UtcNow;
            chapter.CreatedBy = User.FindFirst("UserId").Value;

            _chapterRepository.CreateChapter(chapter);
            await _unitOfWork.CompleteAsync();

            return Ok(chapter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChapter(int? id, [FromBody] SaveChapterResources resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == null || id == 0)
            {
                return BadRequest("Please enter ID");
            }

            var result = await _chapterRepository.GetChapterAsync(id);
            if (result == null)
            {
                return NotFound("No data found");
            }

            var data = _mapper.Map(resources, result);

            _chapterRepository.UpdateChapter(data);
            await _unitOfWork.CompleteAsync();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Please enter ID");
            }

            var result = await _chapterRepository.GetChapterAsync(id);
            if (result == null)
            {
                return NotFound("No data found");
            }

            result.IsDeleted = true;
            
            _chapterRepository.UpdateChapter(result);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}