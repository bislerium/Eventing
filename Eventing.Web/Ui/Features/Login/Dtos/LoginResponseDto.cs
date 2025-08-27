namespace Eventing.Web.Ui.Features.Login.Dtos;

public sealed record LoginResponseDto(string AccessToken, long ExpiresIn);