using Eventing.Web.Ui.Features.Event.Toolbar.CreateEvent.Dialog.Dtos;
using Eventing.Web.Ui.Features.Event.Toolbar.CreateEvent.Dialog.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using System.Net.Http.Headers;

namespace Eventing.Web.Ui.Features.Event.Toolbar.CreateEvent.Dialog;

public partial class CreateEventDialog(ProtectedLocalStorage protectedLocalStorage, IHttpClientFactory httpClientFactory, ISnackbar snackbar) : ComponentBase
{
    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = null!;

    private CreateEventModel CreateEventModel { get; set; } = new();

    private bool _isLoading;

    private async Task CreateEventAsync()
    {
        this._isLoading = true;

        var requestDto = new CreateEventRequestDto(
            CreateEventModel.Title,
            CreateEventModel.Description,
            CreateEventModel.StartDate.Value + CreateEventModel.StartTime.Value,
            CreateEventModel.EndDate.Value + CreateEventModel.EndTime.Value,
            CreateEventModel.LocationType,
            CreateEventModel.Location,
            CreateEventModel.ShowAttendees);

        using var request = new HttpRequestMessage(HttpMethod.Post, "api/events");
        request.Content = JsonContent.Create(requestDto);
        var token = await protectedLocalStorage.GetAsync<string>("AccessToken");
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token.Value);
        var response = await httpClientFactory
            .CreateClient(Constants.HttpClients.EventingApi.Name)
            .SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            snackbar.Add("Successfully created event", Severity.Success);
            var content = response.Content.ReadFromJsonAsync<EventResponseDto>();
            // add the content to the the list of events.
            this.MudDialog.Close();
        }
        else
        {
            snackbar.Add(Constants.ErrorMessages.SomethingWentWrong, Severity.Error);
        }

        this._isLoading = false;
    }
}