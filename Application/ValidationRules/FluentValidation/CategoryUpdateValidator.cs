using Application.Dtos;
using FluentValidation;
using Persistence.Abstract;
using Persistence.Concrete.EntityFramework;

namespace Application.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator(ICategoryDal categoryDal)
        {
            RuleFor(u => u.Name).NotEmpty().NotNull();
            RuleFor(u => u.Description).NotNull();
        }
    }
}