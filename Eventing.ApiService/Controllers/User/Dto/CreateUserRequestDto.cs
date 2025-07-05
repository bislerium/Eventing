using System.ComponentModel.DataAnnotations;

namespace Eventing.ApiService.Controllers.User.Dto;

public record CreateUserRequestDto(
    [Required] [MaxLength(64)] string Name,
    [Required] [EmailAddress] string Email,
    [Required] [MaxLength(128)] string Address
);