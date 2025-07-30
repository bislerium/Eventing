namespace Eventing.Web.Features.Login.Models.Http;

public sealed record LoginResponseDto(
    string AccessToken,
    long ExpiresIn
);