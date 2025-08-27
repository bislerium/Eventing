using Eventing.Web.Ui.Features.Attendee.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using System.Net.Http.Headers;

namespace Eventing.Web.Ui.Features.Attendee.Dialog;

public partial class AttendeesDialog(
    IHttpClientFactory clientFactory,
    ProtectedLocalStorage protectedLocalStorage,
    ISnackbar snackbar) : ComponentBase
{
    private bool _isLoading;

    [Parameter] public Guid EventId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await FetchAttendeesAsync();
        CommentVisibility = Attendees
            .Where(x => !string.IsNullOrEmpty(x.Comment))
            .ToDictionary(x => x.AttendeeId, _ => false);
    }

    private IEnumerable<AttendeeResponseDto> Attendees { get; set; } = new List<AttendeeResponseDto>();

    private Dictionary<Guid, bool> CommentVisibility { get; set; } = [];

    private void ToggleComment(Guid attendeeId)
    {
        var found = CommentVisibility.TryGetValue(attendeeId, out var isVisible);
        if (!found) return;
        CommentVisibility[attendeeId] = !isVisible;
    }

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