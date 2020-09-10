using FluentValidation;
using VotingApplication.Models.ViewModel;
using VotingApplication.Models.Validations.Helper;
using System.Linq;

namespace VotingApplication.Validations
{
    public class CandidateVMValidator : AbstractValidator<CandidateVM>
    {
        public CandidateVMValidator()
        {
            RuleFor(s => s.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithName("Name").WithMessage("{PropertyName} is required.")
                .Length(2, 255).WithMessage("Invalid length {TotalLength} for {PropertyName}")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(model => model).Custom((model, context) =>
            {
                if (!new RepositoryHelper().ValidateCandidateNameExistence(model.Name))
                {
                    context.AddFailure("Name", "Candidate name already exists");
                    return;
                }
            });

        }

        protected bool BeAValidName(string name) =>
            name.Replace(" ", string.Empty).Replace("-", string.Empty).All(char.IsLetter);
        
    }
}
