using Eventing.Web.Features.Login.Models;
using Eventing.Web.Features.Login.Models.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Eventing.Web.Features.Login;

public partial class LoginPage(
    NavigationManager navigationManager,
    IToastService toastService,
    ProtectedLocalStorage protectedLocalStorage,
    ProtectedSessionStorage protectedSessionStorage,
    IHttpClientFactory clientFactory) : ComponentBase
{
    private LoginModel LoginModel { get; set; } = new();

    private async Task SubmitAsync()
    {
        var requestDto = new LoginRequestDto(LoginModel.Email, LoginModel.Password);
        var response = await clientFactory
            .CreateClient(HttpClientNames.EventingApi)
            .PostAsJsonAsync("api/account/login", requestDto);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            ArgumentNullException.ThrowIfNull(content);

            if (LoginModel.RememberMe)
            {
                await protectedLocalStorage.SetAsync(nameof(LoginResponseDto.AccessToken), content.AccessToken);
                await protectedLocalStorage.SetAsync(nameof(LoginResponseDto.ExpiresIn), content.ExpiresIn);
            }
            else
            {
                await protectedSessionStorage.SetAsync(nameof(LoginResponseDto.AccessToken), content.AccessToken);
                await protectedSessionStorage.SetAsync(nameof(LoginResponseDto.ExpiresIn), content.ExpiresIn);
            }


            navigationManager.NavigateTo("/home", replace: true);
            return;
        }

        toastService.ShowError("Login failed.");
    }
}