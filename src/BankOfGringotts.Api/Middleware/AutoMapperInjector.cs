using BankOfGringotts.Bussiness.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace BankOfGringotts.Api.Middleware
{
    public static class AutoMapperInjector
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AccountMappers).Assembly);
            services.AddAutoMapper(typeof(CustomerMappers).Assembly);
        }
    }
}
