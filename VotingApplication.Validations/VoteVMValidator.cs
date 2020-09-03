using FluentValidation;
using VotingApplication.Models.API_Models;

namespace VotingApplication.Validations
{
    public class VoteVMValidator : AbstractValidator<VoteVM>
    {
        public VoteVMValidator()
        {
            RuleFor(s => s.CandidateId).NotEmpty().WithName("Candidate Id").WithMessage("{PropertyName} is required.");
            RuleFor(s => s.CategoryId).NotEmpty().WithName("Category Id").WithMessage("{PropertyName} is required.");
            RuleFor(s => s.VoterId).NotEmpty().WithName("Voter Id").WithMessage("{PropertyName} is required.");
        }
    }
}
