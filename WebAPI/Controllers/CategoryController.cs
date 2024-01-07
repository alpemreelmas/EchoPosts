using Applciation.Abstract;
using Application.Dtos;
using Application.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {

        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/")]
        public IResult GetAll()
        {
            var category = _categoryService.GetAll();
            return new SuccessDataResult<List<Category>>(category.Data);
        }


        [HttpGet("/{slug}")]
        public IResult GetBySlug(string slug)
        {
            var category = _categoryService.GetBySlug(slug);
            return new SuccessDataResult<Category>(category.Data);
        }

        [Authorize]
        [HttpPost("/")]
        [ValidationAspect(typeof(CategoryStoreValidator))]
        public IActionResult Store([FromBody] CategoryStoreDto categoryStoreDto)
        {
            var result = _categoryService.Store(categoryStoreDto);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [Authorize]
        [HttpDelete("/{id}")]
        public IResult Remove(int id)
        {
            var result = _categoryService.Remove(id);
            return new SuccessResult(result.Message);
        }

        [Authorize]
        [HttpGet("/{id}/edit")]
        public IResult Edit(int id)
        {
            var result = _categoryService.GetById(id);
            return new SuccessDataResult<Category>(result.Data, result.Message);
        }

        [Authorize]
        [HttpPut("/{id}")]
        public IActionResult Update([FromBody] CategoryUpdateDto categoryUpdateDto, int id)
        {
            var result = _categoryService.Update(categoryUpdateDto,id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
