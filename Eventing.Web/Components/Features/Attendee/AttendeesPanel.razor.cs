using System.Net.Http.Headers;
using Eventing.Web.Components.Features.Attendee.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;

namespace Eventing.Web.Components.Features.Attendee;

public partial class AttendeesPanel(
    IHttpClientFactory clientFactory,
    ProtectedLocalStorage protectedLocalStorage,
    ISnackbar snackbar) : ComponentBase
{
    private bool _isLoading;

    [Parameter] public Guid EventId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await FetchAttendeesAsync();
    }
    
    [Parameter] public bool Open { get; set; }
    [Parameter] public EventCallback<bool> OpenChanged { get; set; }

    private async Task SetOpen(bool value)
    {
        if (Open != value)
        {
            Open = value;
            await OpenChanged.InvokeAsync(value);
        }
    }


    private IEnumerable<AttendeeResponseDto> Attendees { get; set; } = new List<AttendeeResponseDto>();

    private async Task FetchAttendeesAsync(CancellationToken cancellationToken = default)
    {
        _isLoading = true;
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/events/{EventId}/attendees");
        var token = await protectedLocalStorage.GetAsync<string>("AccessToken");
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token.Value);

        var response = await clientFactory
            .CreateClient(Constants.HttpClients.EventingApi.Name)
            .SendAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<AttendeeResponseDto>>(cancellationToken);
            if (content == null)
            {
                snackbar.Add(Constants.ErrorMessages.SomethingWentWrong, Severity.Error);
            }
            else
            {
                Attendees = content;
            }
        }
        else
        {
            snackbar.Add(Constants.ErrorMessages.SomethingWentWrong, Severity.Error);
        }

        _isLoading = false;
    }
}