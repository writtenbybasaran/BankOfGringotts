using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BankOfGringotts.Common.Exceptions;
using BankOfGringotts.Contracts.Requests.Authorization;
using BankOfGringotts.Contracts.Responses.Authorization;
using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ValidationException = FluentValidation.ValidationException;

namespace BankOfGringotts.Bussiness.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IValidator<AuthorizationRequest> _validator;

        private const string ClientName = "Web";
        private const string ClientUser = "Getir";
        private const string ClientPassword = "Getir123";
        private const string ApiSecret = "a4db08b7-5729-4ba9-8c08-f2df493465a1";
        private const string ApiIssuer = "http://mysite.com";
        private const string ApiAudience = "http://myaudience.com";


        public AuthorizationService(IValidator<AuthorizationRequest> validator)
        {
            _validator = validator;
        }

        public async Task<AuthorizationResponse> GetAccessToken(AuthorizationRequest authorizationRequest)
        {
            var validationResult = await _validator.ValidateAsync(authorizationRequest);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.ToString());

            if (ClientName.Equals(authorizationRequest.ClientName) &&
                ClientUser.Equals(authorizationRequest.ClientUser) &&
                ClientPassword.Equals(authorizationRequest.ClientPassword))
            {

                var apiToken = await GenerateToken(authorizationRequest.ClientUser);
                return await Task.FromResult(new AuthorizationResponse()
                {
                    Token = apiToken
                });

            }

            throw new AuthenticationException("Authorization Parameters not valid");
        }


        private Task<string> GenerateToken(string clientUser)
        {
            var tokenDescriptor = SecurityTokenDescriptor(clientUser);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));

        }

        private SecurityTokenDescriptor SecurityTokenDescriptor(string clientUser)
        {
            var apiSecret = ApiSecret;
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(apiSecret));
            var Issuer = ApiIssuer;
            var Audience = ApiAudience;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, clientUser.ToString()),
                    new Claim("Role", "ApiUser")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }
    }
}
