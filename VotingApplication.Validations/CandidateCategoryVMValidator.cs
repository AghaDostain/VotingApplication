using FluentValidation;
using VotingApplication.Models.API_Models;
using VotingApplication.Models.Validations.Helper;

namespace VotingApplication.Validations
{
    public class CandidateCategoryVMValidator : AbstractValidator<CandidateCategoryVM>
    {
        public CandidateCategoryVMValidator()
        {
            RuleFor(s => s.CandidateId).NotEmpty().WithName("Candidate Id").WithMessage("{PropertyName} is required.");
            RuleFor(s => s.CategoryId).NotEmpty().WithName("Category Id").WithMessage("{PropertyName} is required.");
            var helper = new RepositoryHelper();
            RuleFor(model => model).Custom(async (model, context) => { 
                if(!(await helper.ValidateCandidate(model.CandidateId)))
                {
                    context.AddFailure("CandidateId", "Candidate doesn't exists");
                    return;
                }
                
                if(!(await helper.ValidateCategory(model.CategoryId)))
                {
                    context.AddFailure("CategoryId", "Category doesn't exists");
                    return;
                }
            });
        }
    }
}
