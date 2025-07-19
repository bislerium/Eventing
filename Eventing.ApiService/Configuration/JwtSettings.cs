using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Eventing.ApiService.Configuration;

public class JwtSettings
{
    public const string SectionName = "Jwt";

    [Required] public string Issuer { get; set; } = null!;

    [Required] public string Audience { get; set; } = null!;

    [Required] [Range(1, int.MaxValue)] public int ExpiryInMinutes { get; set; }

    // typically representing a 32-byte (256-bit) key used for HMAC-SHA-256 signing.
    [Required] [MinLength(32)] public string SigningKey { get; set; } = null!;

    // Representing a 16-byte (128-bit) key required for AES-128 encryption.
    [StringLength(16, MinimumLength = 16)] public string? EncryptingKey { get; set; }

    public EncryptingCredentials? EncryptingCredentials => EncryptingKey == null
        ? null
        : new EncryptingCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EncryptingKey)),
            SecurityAlgorithms.Aes128KW,
            SecurityAlgorithms.Aes128CbcHmacSha256
        );

    public SigningCredentials SigningCredentials => new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey)),
        SecurityAlgorithms.HmacSha256);
}