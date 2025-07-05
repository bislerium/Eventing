using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eventing.ApiService.Controllers.User.Dto;

public sealed record UpdateUserRequestDto
{
    [Required]
    [MaxLength(64)]
    [RegularExpression("^[A-Za-z ]+$")]
    [Description("The user's full name, up to 64 characters")]
    public required string Name { get; init; }

    [Required]
    [EmailAddress]
    [Description("The user's email address")]
    public required string Email { get; init; }

    [Required]
    [MaxLength(128)]
    [Description("The user's address, up to 128 characters")]
    public required string Address { get; init; }
}