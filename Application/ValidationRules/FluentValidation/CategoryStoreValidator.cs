using Application.Dtos;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation
{
    public class CategoryStoreValidator : AbstractValidator<CategoryStoreDto>
    {
        public CategoryStoreValidator()
        {
            RuleFor(u => u.Name).NotEmpty().NotNull();
            RuleFor(u => u.Description).NotNull();
        }
    }
}