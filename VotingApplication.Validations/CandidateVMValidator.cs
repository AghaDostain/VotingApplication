using FluentValidation;
using VotingApplication.Models.ViewModel;
using VotingApplication.Models.Validations.Helper;

namespace VotingApplication.Validations
{
    public class CandidateVMValidator : AbstractValidator<CandidateVM>
    {
        public CandidateVMValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithName("Name").WithMessage("{PropertyName} is required.");
            RuleFor(model => model).Custom((model, context) =>
            {
                if (!new RepositoryHelper().ValidateCandidateNameExistence(model.Name))
                {
                    context.AddFailure("Name", "Candidate name already exists");
                    return;
                }
            });
        }
    }
}
