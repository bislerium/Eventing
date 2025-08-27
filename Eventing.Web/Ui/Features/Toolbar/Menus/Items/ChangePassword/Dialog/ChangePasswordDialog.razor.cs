using Eventing.Web.Ui.Features.Toolbar.Menus.Items.ChangePassword.Dialog.Dtos;
using Eventing.Web.Ui.Features.Toolbar.Menus.Items.ChangePassword.Dialog.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using System.Net.Http.Headers;

namespace Eventing.Web.Ui.Features.Toolbar.Menus.Items.ChangePassword.Dialog;

public partial class ChangePasswordDialog(
    IHttpClientFactory httpClientFactory,
    ProtectedLocalStorage protectedLocalStorage,
    ISnackbar snackbar) : ComponentBase
{
    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = null!;

    private ChangePasswordModel ChangePasswordModel { get; set; } = new();

    private bool _isLoading;

    private async Task UpdatePasswordAsync()
    {
        this._isLoading = true;

        await Task.Delay(3000);
        var requestDto = new ChangePasswordRequestDto(ChangePasswordModel.OldPassword, ChangePasswordModel.NewPassword);

        using var request = new HttpRequestMessage(HttpMethod.Post, "api/account/change-password");
        request.Content = JsonContent.Create(requestDto);
        var token = await protectedLocalStorage.GetAsync<string>("AccessToken");
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token.Value);
        var response = await httpClientFactory
            .CreateClient(Constants.HttpClients.EventingApi.Name)
            .SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            snackbar.Add("Successfully changed password", Severity.Success);
            MudDialog.Close();
        }
        else
        {
            snackbar.Add(Constants.ErrorMessages.SomethingWentWrong, Severity.Error);
        }

        _isLoading = false;
    }
}