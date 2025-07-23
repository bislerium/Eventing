using System.Security.Claims;
using Eventing.ApiService.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Eventing.ApiService.Services.Jwt;

public class JwtTokenService(IOptions<JwtSettings> jwtSettings)
{
    public (string Token, long ExpiresIn) CreateToken(IEnumerable<Claim> claims)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = jwtSettings.Value.Issuer,
            Audience = jwtSettings.Value.Audience,
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(jwtSettings.Value.ExpiryInMinutes),
            NotBefore = DateTime.UtcNow,
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = jwtSettings.Value.SigningCredentials,
            EncryptingCredentials = jwtSettings.Value.EncryptingCredentials
        };

        var token = new JsonWebTokenHandler().CreateToken(tokenDescriptor);

        return (token, jwtSettings.Value.ExpiryInMinutes * 60);
    }
}