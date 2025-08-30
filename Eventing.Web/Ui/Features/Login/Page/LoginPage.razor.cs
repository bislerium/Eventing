using Eventing.Web.Ui.Features.Login.Page.Dtos;
using Eventing.Web.Ui.Features.Login.Page.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using MudBlazor;

namespace Eventing.Web.Ui.Features.Login.Page;

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
        this._loggingIn = true;

        var requestDto = new LoginRequestDto(this.LoginModel.Email, this.LoginModel.Password);
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

        this._loggingIn = false;
    }
}