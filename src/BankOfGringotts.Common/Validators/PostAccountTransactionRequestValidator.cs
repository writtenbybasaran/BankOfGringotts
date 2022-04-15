using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfGringotts.Contracts.Requests.AccountTransaction;
using FluentValidation;

namespace BankOfGringotts.Common.Validators
{
    public class PostAccountTransactionRequestValidator : AbstractValidator<PostAccountTransactionRequest>
    {
        public PostAccountTransactionRequestValidator()
        {
            RuleFor(x => x.AccountNo)
                .NotNull()
                .NotEmpty()
                .NotEqual(Guid.Empty);
            RuleFor(x => x.TransactionValue)
                .NotNull()
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
