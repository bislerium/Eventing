using System.ComponentModel.DataAnnotations;

namespace Eventing.ApiService.Controllers.User.Dto;

public class UpdateUserRequestDto
{
    [MaxLength(64)]
    [Required]
    public required string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Required]
    [MaxLength(128)]
    public required string Address { get; set; }
}