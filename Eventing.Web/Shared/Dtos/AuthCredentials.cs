namespace Eventing.Web.Shared.Dtos;

public record AuthCredentials(
    string AccessToken,
    long ExpiresIn);