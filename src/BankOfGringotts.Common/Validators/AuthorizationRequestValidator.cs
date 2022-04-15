using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfGringotts.Contracts.Requests.Authorization;
using FluentValidation;

namespace BankOfGringotts.Common.Validators
{
    public class AuthorizationRequestValidator : AbstractValidator<AuthorizationRequest>
    {
        public AuthorizationRequestValidator()
        {
            RuleFor(r => r.ClientName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Client Name cannot be null or empty");
            RuleFor(r => r.ClientUser)
                .NotEmpty()
                .NotNull()
                .WithMessage("Client User cannot be null or empty");
            RuleFor(r => r.ClientPassword)
                .NotEmpty()
                .NotNull()
                .WithMessage("Client Password cannot be null or empty");
        }
    }
}
