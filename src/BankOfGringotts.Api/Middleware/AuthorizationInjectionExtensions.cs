using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BankOfGringotts.Api.Middleware
{
    public static class AuthorizationInjectionExtensions
    {
        private const string ApiSecret = "a4db08b7-5729-4ba9-8c08-f2df493465a1";
        public static void UseCustomJwtAuthorize(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ApiSecret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}
