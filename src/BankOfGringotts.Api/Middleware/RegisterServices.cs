using BankOfGringotts.Bussiness.Services;
using BankOfGringotts.Bussiness.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BankOfGringotts.Api.Middleware
{
    public static class RegisterServices
    {
        public static void UseRegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountTransactionService, AccountTransactionService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
        }
    }
}
