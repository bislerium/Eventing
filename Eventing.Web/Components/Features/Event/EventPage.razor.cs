using System.Net.Http.Headers;
using Eventing.Web.Components.Features.Attendee;
using Eventing.Web.Components.Features.Event.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Eventing.Web.Components.Features.Event;

public partial class EventPage(
    IHttpClientFactory clientFactory,
    IToastService toastService,
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
        var token = await protectedLocalStorage.GetAsync<string>(nameof(Constants.UserContextKey.AccessToken));
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token.Value);

        var response = await clientFactory
            .CreateClient(Constants.HttpClients.EventingApi.Name)
            .SendAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<EventResponseDto>>(cancellationToken);
            if (content == null)
            {
                toastService.ShowError(Constants.ErrorMessages.SomethingWentWrong);
            }
            else
            {
                Events = content;
            }
        }
        else
        {
            toastService.ShowError(Constants.ErrorMessages.SomethingWentWrong);
        }

        IsLoading = false;
    }
    
    private async Task OpenAttendeesPanelAsync(Guid eventId)
    {
        var parameters = new DialogParameters<AttendeesPanel>
        {
            Title = "Attendees",
            Alignment = HorizontalAlignment.Left,
            Modal = false,
            ShowDismiss = true,
            PrimaryAction = null,
            SecondaryAction = null,
            ["EventId"] = eventId
        };

        await dialogService.ShowPanelAsync<AttendeesPanel>(parameters);
    }
}