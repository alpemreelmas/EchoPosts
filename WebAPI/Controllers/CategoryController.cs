using Applciation.Abstract;
using Application.Dtos;
using Application.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/")]
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

        [HttpPost("/")]
        [ValidationAspect(typeof(CategoryStoreValidator))]
        public IResult Store(CategoryStoreDto categoryStoreDto)
        {
            var result = _categoryService.Store(categoryStoreDto);
            return new SuccessResult(result.Message);
        }
    }
}
