using System;
using FluentValidation;
using VotingApplication.Models.API_Models;

namespace VotingApplication.Validations
{
    public class VoterVMValidator : AbstractValidator<VoterVM>
    {
        public VoterVMValidator()
        {
            RuleFor(s => s.DOB).NotEmpty().WithName("Date of Birth").WithMessage("{PropertyName} is required.");
            RuleFor(s => s.Name).NotEmpty().WithName("Name").WithMessage("{PropertyName} is required.");
            RuleFor(model => model).Custom((model, context) =>
            {
                if (DateTime.UtcNow.Year - model.DOB.Year < 18)
                {
                    context.AddFailure("Date of Birth", "Your age must be above 18.");
                }
            });
        }
    }
}
