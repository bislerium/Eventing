namespace Eventing.Web.Components.Features.Login.Dtos;

public sealed record LoginResponseDto(string AccessToken, long ExpiresIn);