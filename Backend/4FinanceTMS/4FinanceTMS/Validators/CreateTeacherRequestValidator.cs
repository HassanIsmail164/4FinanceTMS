using _4FinanceTMS.InputModels;
using FluentValidation;

namespace _4FinanceTMS.Validators
{
    public class CreateTeacherRequestValidator: AbstractValidator<CreateTeacherInputModel>
    {
        public CreateTeacherRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();   
            RuleFor(x => x.Specality).NotEmpty();
        }
    }
}
