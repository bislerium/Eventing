using Eventing.Web.Shared.Dtos;

namespace Eventing.Web.Components.Features.Login.Dtos;

public sealed record LoginResponseDto(string AccessToken, long ExpiresIn) 
    : AuthCredentials(AccessToken, ExpiresIn);