using FluentValidation;
using VotingApplication.Models.API_Models;

namespace VotingApplication.Validations
{
    public class CategoryVMValidator : AbstractValidator<CategoryVM>
    {
        public CategoryVMValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithName("Name").WithMessage("{PropertyName} is required.");
        }
    }
}
