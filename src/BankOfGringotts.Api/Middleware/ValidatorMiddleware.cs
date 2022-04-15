using BankOfGringotts.Common.Validators;
using BankOfGringotts.Contracts.Requests.Account;
using BankOfGringotts.Contracts.Requests.AccountTransaction;
using BankOfGringotts.Contracts.Requests.Authorization;
using BankOfGringotts.Contracts.Requests.Customer;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace BankOfGringotts.Api.Middleware
{
    public static class ValidatorMiddleware
    {
        public static void AddGringottsValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<PostAccountRequest>, PostAccountRequestValidator>();
            services.AddScoped<IValidator<PostAccountTransactionRequest>, PostAccountTransactionRequestValidator>();
            services.AddScoped<IValidator<PostCustomerRequest>, PostCustomerRequestValidator>();
            services.AddScoped<IValidator<AuthorizationRequest>, AuthorizationRequestValidator>();
        }
    }
}
