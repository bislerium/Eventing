using Eventing.ApiService.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Eventing.ApiService.Setup.Jwt;

public class JwtBearerConfigureOptions(IOptions<JwtSettings> jwtSettingsOption)
    : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtSettings _jwtSettings = jwtSettingsOption.Value;

    public void Configure(string? name, JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            RequireAudience = true,
            RequireSignedTokens = true,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.FromMinutes(2), // 2 minutes

            // Set both keys — for decrypting & validating
            TokenDecryptionKey = _jwtSettings.EncryptingCredentials?.Key,
            IssuerSigningKey = _jwtSettings.SigningCredentials.Key
        };
    }

    public void Configure(JwtBearerOptions options) => Configure(Options.DefaultName, options);
}