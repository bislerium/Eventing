using System.ComponentModel.DataAnnotations;

namespace Eventing.Web.Features.Login.Models;

public class LoginModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
    
    public bool RememberMe { get; set; }
}
