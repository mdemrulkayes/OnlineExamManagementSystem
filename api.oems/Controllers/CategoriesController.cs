using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.CategoriesInInstitutes;
using api.oems.Controllers.Resources.Category;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoriesInInstitutesRepository _categoriesInInstitutesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository, ICategoriesInInstitutesRepository categoriesInInstitutesRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _categoriesInInstitutesRepository = categoriesInInstitutesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var data = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResources>>(await _categoryRepository.GetAllCategoryAsync(User.FindFirst("UserId").Value));
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategories(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id can not be empty");
            }
            return Ok(_mapper.Map<Category,CategoryResources>(await _categoryRepository.GetCategoryByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]SaveCategoryResources resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = _mapper.Map<SaveCategoryResources, Category>(resources);
            data.CreatedBy = User.FindFirst("UserId").Value;
            data.CreatedDate = DateTime.UtcNow;
            data.IsDeleted = false;

            _categoryRepository.CreateCategory(data);
            await _unitOfWork.CompleteAsync();

            foreach (var institute in resources.InstituteId)
            {
                var categoriesInInstitute = new SaveCategoriesInInstituteResources()
                {
                    CategoryId = data.Id,
                    InstituteId = institute
                };

                _categoriesInInstitutesRepository.Create(_mapper.Map<SaveCategoriesInInstituteResources,CategoriesInInstitute>(categoriesInInstitute));
                await _unitOfWork.CompleteAsync();
            }

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int? id, [FromBody] SaveCategoryResources resources)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id == null)
                {
                    return BadRequest("Id can not be Null");
                }
                var data = await _categoryRepository.GetCategoryByIdAsync(id);

                if (data == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map(resources, data);
                _categoryRepository.UpdateCategory(result);

                foreach (var previousInstituteData in result.Institutes)
                {
                    _categoriesInInstitutesRepository.Delete(previousInstituteData);
                }

                foreach (var institute in resources.InstituteId)
                {
                    var categoriesInInstitute = new SaveCategoriesInInstituteResources()
                    {
                        CategoryId = data.Id,
                        InstituteId = institute
                    };

                    _categoriesInInstitutesRepository.Create(_mapper.Map<SaveCategoriesInInstituteResources, CategoriesInInstitute>(categoriesInInstitute));
                }

                await _unitOfWork.CompleteAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }
            
        }
    }
}