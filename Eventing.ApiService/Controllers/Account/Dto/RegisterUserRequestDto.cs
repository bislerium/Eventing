using System.ComponentModel.DataAnnotations;
using Eventing.ApiService.Utils;
using Eventing.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Eventing.ApiService.Controllers.Account.Dto;

public sealed record RegisterUserRequestDto
{
    private readonly Guid _id = Guid.NewGuid();

    [Required]
    [RegularExpression(CustomRegex.FullNameRegexPattern)]
    public string Name { get; init; } = null!;

    [Required] [EmailAddress] public string Email { get; init; } = null!;

    public string Password { get; init; } = null!;

    [Compare(nameof(Password))] public string ConfirmPassword { get; init; } = null!;

    public static implicit operator IdentityUser<Guid>(RegisterUserRequestDto dto) =>
        new() { Id = dto._id, UserName = dto._id.ToString(), Email = dto.Email };

    public static implicit operator Profile(RegisterUserRequestDto dto) => new() { Id = dto._id, Name = dto.Name };
}