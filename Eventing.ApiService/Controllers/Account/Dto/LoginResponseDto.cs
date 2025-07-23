namespace Eventing.ApiService.Controllers.Account.Dto;

public sealed record LoginResponseDto(
        string AccessToken,
        long ExpiresIn
    );