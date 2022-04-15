using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfGringotts.Contracts.Requests.Account;
using FluentValidation;

namespace BankOfGringotts.Common.Validators
{
    public class PostAccountRequestValidator : AbstractValidator<PostAccountRequest>
    {
        public PostAccountRequestValidator()
        {
            RuleFor(x => x.CustomerNo).NotNull();
        }
    }
}
