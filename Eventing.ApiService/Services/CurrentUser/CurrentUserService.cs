using System.Security.Claims;

namespace Eventing.ApiService.Services.CurrentUser;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor)
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext
                                                ?? throw new ArgumentNullException(
                                                    nameof(httpContextAccessor.HttpContext));

    public Guid UserId => Guid.TryParse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId)
        ? userId
        : throw new Exception("User is not authenticated.");
}