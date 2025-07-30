using System.ComponentModel.DataAnnotations;

namespace Eventing.Web.Features.Login.Models;

public sealed class LoginModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
    
    public bool RememberMe { get; set; }
}
