using FluentValidation;
using VotingApplication.Models.ViewModel;
using VotingApplication.Models.Validations.Helper;

namespace VotingApplication.Validations
{
    public class VoteVMValidator : AbstractValidator<VoteVM>
    {
        public VoteVMValidator()
        {
            RuleFor(s => s.CandidateId).NotEmpty().WithName("Candidate Id").WithMessage("{PropertyName} is required.");
            RuleFor(s => s.CategoryId).NotEmpty().WithName("Category Id").WithMessage("{PropertyName} is required.");
            RuleFor(s => s.VoterId).NotEmpty().WithName("Voter Id").WithMessage("{PropertyName} is required.");
            RuleFor(model => model).Custom((model, context) =>
            {
                var helper = new RepositoryHelper();

                if (!helper.ValidateCandidate(model.CandidateId))
                {
                    context.AddFailure("CandidateId", "Candidate doesn't exists");
                }

                if (!helper.ValidateCategory(model.CategoryId))
                {
                    context.AddFailure("CategoryId", "Category doesn't exists");
                }

                if (!helper.ValidateVoter(model.VoterId))
                {
                    context.AddFailure("VoterId", "Voter doesn't exists");
                    return;
                }

                if (!helper.ValidateCandidateCategory(model.CandidateId, model.CategoryId))
                {
                    context.AddFailure("CandidateId", "Candidate doesn't exists in category");
                }
            });
        }
    }
}
