using BankOfGringotts.Common.Helpers.RepoHelper;
using BankOfGringotts.Context.Repository;
using BankOfGringotts.Context.Repository.Base;
using BankOfGringotts.Model;
using Microsoft.Extensions.DependencyInjection;

namespace BankOfGringotts.Api.Middleware
{
    public static class ConfigureRepositoryWrapper
    {
        public static void AddConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
