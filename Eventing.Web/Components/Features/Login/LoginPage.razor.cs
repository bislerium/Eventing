using Eventing.Web.Components.Features.Login.Dtos;
using Eventing.Web.Components.Features.Login.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FluentUI.AspNetCore.Components;
using static Eventing.Web.Constants;

namespace Eventing.Web.Components.Features.Login;

public partial class LoginPage(
    NavigationManager navigationManager,
    IToastService toastService,
    ProtectedLocalStorage protectedLocalStorage,
    IHttpClientFactory clientFactory) : ComponentBase
{
    private LoginModel LoginModel { get; } = new();

    private async Task SubmitAsync()
    {
        var requestDto = new LoginRequestDto(LoginModel.Email, LoginModel.Password);
        var response = await clientFactory
            .CreateClient(HttpClients.EventingApi.Name)
            .PostAsJsonAsync("api/account/login", requestDto);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            ArgumentNullException.ThrowIfNull(content);
            
            var rememberMe = LoginModel.RememberMe;
            
            // Further to do
            await protectedLocalStorage.SetAsync(nameof(UserContextKey.AccessToken), content.AccessToken);
            
            navigationManager.NavigateTo("/event", replace: true);
            return;
        }

        try
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            toastService.ShowError(problemDetails?.Detail ?? ErrorMessages.SomethingWentWrong);
        }
        catch
        {
            toastService.ShowError(ErrorMessages.SomethingWentWrong);
        }
    }
}