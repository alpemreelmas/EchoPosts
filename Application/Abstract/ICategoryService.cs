using Application.Dtos;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Applciation.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
        IDataResult<Category> GetBySlug(string categorySlug);
        IResult Store(CategoryStoreDto categoryStoreDto);
    }
}
