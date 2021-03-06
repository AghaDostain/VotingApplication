﻿using FluentValidation;
using VotingApplication.Models.Validations.Helper;
using VotingApplication.Models.ViewModel;

namespace VotingApplication.Validations
{
    public class CategoryVMValidator : AbstractValidator<CategoryVM>
    {
        public CategoryVMValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithName("Name").WithMessage("{PropertyName} is required.");
            RuleFor(model => model).Custom((model, context) =>
            {
                if (!new RepositoryHelper().ValidateCategoryNameExistence(model.Name))
                {
                    context.AddFailure("Name", "Category name already exists");
                    return;
                }
            });
        }
    }
}
