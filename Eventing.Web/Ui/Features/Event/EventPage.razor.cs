using Eventing.Web.Ui.Features.Attendee.Dialog;
using Eventing.Web.Ui.Features.Event.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using System.Net.Http.Headers;

namespace Eventing.Web.Ui.Features.Event;

public partial class EventPage(
    IHttpClientFactory clientFactory,
    ISnackbar snackbar,
    IDialogService dialogService,
    ProtectedLocalStorage protectedLocalStorage) : ComponentBase
{
    private bool IsLoading { get; set; } = true;

    private IEnumerable<EventResponseDto> Events { get; set; } = new List<EventResponseDto>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Task.Delay(2000);
            await FetchEventsAsync();
            StateHasChanged();
        }
    }

    private async Task FetchEventsAsync(CancellationToken cancellationToken = default)
    {
        IsLoading = true;

        var request = new HttpRequestMessage(HttpMethod.Get, "api/events");
        var token = await protectedLocalStorage.GetAsync<string>("AccessToken");
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token.Value);

        var response = await clientFactory
            .CreateClient(Constants.HttpClients.EventingApi.Name)
            .SendAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<EventResponseDto>>(cancellationToken);
            if (content == null)
            {
                snackbar.Add(Constants.ErrorMessages.SomethingWentWrong, Severity.Error);
            }
            else
            {
                Events = content;
            }
        }
        else
        {
            snackbar.Add(Constants.ErrorMessages.SomethingWentWrong, Severity.Error);
        }

        IsLoading = false;
    }

    private Task OpenAttendeesDialogAsync(Guid eventId)
    {
        var parameters = new DialogParameters<AttendeesDialog> { { x => x.EventId, eventId } };
        var options = new DialogOptions
        {
            BackdropClick = true, CloseOnEscapeKey = true, CloseButton = true, FullWidth = true
        };

        return dialogService.ShowAsync<AttendeesDialog>("Attendees", parameters, options);
    }
}