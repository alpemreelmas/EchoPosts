using Applciation.Abstract;
using Application.Dtos;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Persistence.Abstract;

namespace Application.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //İş kodları
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        //Select * from Categories where CategoryId = 3
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.Id == categoryId));
        }

        public IDataResult<Category> GetBySlug(string categorySlug)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.Slug == categorySlug));
        }

        public IResult Remove(int id)
        {
            var category = _categoryDal.Get(c => c.Id == id);
            _categoryDal.Delete(category);
            return new SuccessResult(Constants.Messages.Removed);
        }

        public IResult Store(CategoryStoreDto categoryStoreDto)
        {
            var existCategory = _categoryDal.Get(c => c.Name == categoryStoreDto.Name);

            if (existCategory is not null)
            {
                return new ErrorResult("You cannot add category already exist.");
            }


            Category category = new Category
            {
                Name = categoryStoreDto.Name,
                Description = categoryStoreDto.Description,
                Slug = categoryStoreDto.Name
            };

            _categoryDal.Add(category);

            return new SuccessResult("Operation is completed.");
        }

        public IResult Update(CategoryUpdateDto categoryUpdateDto, int id)
        {
            // to make it more clear defined a multiple bussines rule runner.
            var existCategory = _categoryDal.Get(c => c.Name == categoryUpdateDto.Name && c.Id != id);

            if(existCategory is not null)
            {
                return new ErrorResult("You cannot add category already exist.");
            }

            // accesing db and getting category object
            // TODO check if I make this more clean like AutoMapper without having performance issue
            var category = _categoryDal.Get(c => c.Id == id);
            category.Description = categoryUpdateDto.Description;
            category.Name= categoryUpdateDto.Name;
            _categoryDal.Update(category);

            return new SuccessDataResult<Category>(category);
        }
    }
}
