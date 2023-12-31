using Applciation.Abstract;
using Application.Dtos;
using Core.Entities.Concrete;
using Core.Utilities.Results;
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
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId == categoryId));
        }

        public IDataResult<Category> GetBySlug(string categorySlug)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.Slug == categorySlug));
        }

        public IResult Store(CategoryStoreDto categoryStoreDto)
        {
            Category category = new Category
            {
                Name = categoryStoreDto.Name,
                Description = categoryStoreDto.Description,
                Slug = categoryStoreDto.Name
            };

            _categoryDal.Add(category);

            return new SuccessResult("Operation is completed.");
        }
    }
}
