using System.ComponentModel;

namespace Eventing.ApiService.Controllers.User.Dto;

public record UserResponse
{
    [Description("The ID of the user")] public required Guid Id { get; init; }

    [Description("The user's full name, up to 64 characters")]
    public required string Name { get; init; }

    [Description("The user's email address")]
    public required string Email { get; init; }

    [Description("The user's address, up to 128 characters")]
    public required string Address { get; init; }
}