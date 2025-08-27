using Eventing.Web.Ui.Features.Login.Dtos;
using Eventing.Web.Ui.Features.Login.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using MudBlazor;

namespace Eventing.Web.Ui.Features.Login;

public partial class LoginPage(
    NavigationManager navigationManager,
    ISnackbar snackbar,
    ProtectedLocalStorage protectedLocalStorage,
    IHttpClientFactory clientFactory) : ComponentBase
{
    private LoginModel LoginModel { get; } = new();

    private bool _loggingIn;

    private async Task LoginAsync()
    {
        if (_loggingIn) return;
        _loggingIn = true;

        var requestDto = new LoginRequestDto(LoginModel.Email, LoginModel.Password);
        var response = await clientFactory
            .CreateClient(Constants.HttpClients.EventingApi.Name)
            .PostAsJsonAsync("api/account/login", requestDto);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            ArgumentNullException.ThrowIfNull(content);

            await protectedLocalStorage.SetAsync("AccessToken", content.AccessToken);

            navigationManager.NavigateTo("/events", replace: true);
        }
        else
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            snackbar.Add(problemDetails?.Detail ?? Constants.ErrorMessages.SomethingWentWrong, Severity.Error);
        }

        _loggingIn = false;
    }
}