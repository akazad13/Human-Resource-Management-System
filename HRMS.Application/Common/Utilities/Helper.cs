using HRMS.Application.Common.Interfaces;
using HRMS.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SoccerApp.Service.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HRMS.Application.Common.Utilities
{
    public class Helper : IHelper
    {
        private readonly ConfigModel _configModel;
        private readonly IIdentityService _identityService;
        public Helper(
            IOptions<ConfigModel> configModel,
            IIdentityService identityService
        )
        {
            _configModel = configModel.Value;
            _identityService = identityService;
        }
        public async Task<string> GenerateJwtToken(User user)
        {
            var signingKey = Convert.FromBase64String(_configModel.Jwt.SigningSecret);
            var expiryDuration = _configModel.Jwt.ExpiryDuration ?? 120;
            var validIssuer = _configModel.Jwt.ValidIssuer;
            var validAudience = _configModel.Jwt.ValidAudience;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())

            };

            var userRoles = await _identityService.GetUserRoles(user);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var creds = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = validIssuer,
                Audience = validAudience,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return token;
        }
    }
}
