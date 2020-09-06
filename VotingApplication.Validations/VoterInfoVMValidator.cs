using System;
using FluentValidation;
using VotingApplication.Models.ViewModel;
using VotingApplication.Models.Validations.Helper;

namespace VotingApplication.Validations
{
    public class VoterInfoVMValidator : AbstractValidator<VoterInfoVM>
    {
        public VoterInfoVMValidator()
        {
            RuleFor(s => s.VoterId).NotEmpty().WithName("VoteId").WithMessage("{PropertyName} is required.");
            RuleFor(s => s.DOB).NotEmpty().WithName("DOB").WithMessage("{PropertyName} is required.");
            RuleFor(model => model).Custom((model, context) =>
            {
                if (!(new RepositoryHelper().ValidateVoter(model.VoterId)))
                {
                    context.AddFailure("VoterId", "Voter doesn't exists");
                }

                if (DateTime.UtcNow.Year - model.DOB.Year < 18)
                {
                    context.AddFailure("Date of Birth", "Your age must be above 18.");
                }
            });
        }
    }
}
