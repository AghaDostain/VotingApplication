using FluentValidation;
using VotingApplication.Models.API_Models;
using VotingApplication.Models.Validations.Helper;

namespace VotingApplication.Validations
{
    public class VoterInfoVMValidator: AbstractValidator<VoterInfoVM>
    {
        public VoterInfoVMValidator()
        {
            RuleFor(s=>s.VoterId).NotEmpty().WithName("VoteId").WithMessage("{PropertyName} is required.");
            RuleFor(s=>s.DOB).NotEmpty().WithName("DOB").WithMessage("{PropertyName} is required.");
            var helper = new RepositoryHelper();
            RuleFor(model => model).Custom(async (model, context) => {
                if (!(await helper.ValidateVoter(model.VoterId)))
                {
                    context.AddFailure("VoterId", "Voter doesn't exists");
                    return;
                }
            });
        }
    }
}
