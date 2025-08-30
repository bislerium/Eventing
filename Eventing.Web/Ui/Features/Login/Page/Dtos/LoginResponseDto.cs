namespace Eventing.Web.Ui.Features.Login.Page.Dtos;

public sealed record LoginResponseDto(string AccessToken, long ExpiresIn);