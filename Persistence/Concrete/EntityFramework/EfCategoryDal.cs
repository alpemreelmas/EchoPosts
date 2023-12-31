using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Persistence.Abstract;
using Persistence.Concrete.EntityFramework;

namespace Persistence.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        
    }
}
