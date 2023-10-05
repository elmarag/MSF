using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSF.Data
{
    public class CPlayerValidator : AbstractValidator<CPlayer> //validating registation info through FluentValidation lib
    {
        public CPlayerValidator() //constructor where the validator lives
        {
            //rule for the validation
            RuleFor(e => e.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty.")
                .Length(2, 64).WithMessage("Length ({TotalLength}) of {PropertyName} is Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} Contains Invalid Characters");

            RuleFor(e => e.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty.")
                .Length(2, 64).WithMessage("Length ({TotalLength}) of {PropertyName} is Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} Contains Invalid Characters");

            RuleFor(e => e.Username)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} is Empty.")
               .Length(2, 64).WithMessage("Length ({TotalLength}) of {PropertyName} is Invalid")
               .Must(BeAValidName).WithMessage("{PropertyName} Contains Invalid Characters");

            RuleFor(e => e.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(2, 64).WithMessage("Length ({TotalLength}) of {PropertyName} is Invalid")
                .EmailAddress().WithMessage("A valid {PropertyName} is required");

            RuleFor(e => e.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty.")
                .Length(5, 64).WithMessage("Length ({TotalLength}) of {PropertyName} is Invalid");

        }

        protected bool BeAValidName(String name) //self-composed validation rule that does not allow special characters in the name
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
