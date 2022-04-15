using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfGringotts.Contracts.Requests.Customer;
using FluentValidation;

namespace BankOfGringotts.Common.Validators
{
    public class PostCustomerRequestValidator : AbstractValidator<PostCustomerRequest>
    {
        public PostCustomerRequestValidator()
        {
            RuleFor(x => x.BirthDate)
                .NotNull()
                .GreaterThan(DateTime.Now.AddYears(-100))
                .LessThan(DateTime.Now.AddYears(-18));
            RuleFor(x => x.IdentityNumber)
                .Length(11)
                .NotEmpty()
                .NotNull()
                .Matches(@"^\d{11}$");
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

        }
    }
}
