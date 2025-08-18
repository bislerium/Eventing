using System.Net.Http.Headers;
using Eventing.Web.Components.Features.Attendee.Dto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Eventing.Web.Components.Features.Attendee;

public partial class AttendeesPanel(
    IHttpClientFactory clientFactory,
    ProtectedLocalStorage protectedLocalStorage,
    IToastService toastService) : ComponentBase
{
    [CascadingParameter] public FluentDialog Dialog { get; set; } = null!;
    private bool IsLoading { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await FetchAttendeesAsync();
    }

    private IEnumerable<AttendeeResponseDto> Attendees { get; set; } = new List<AttendeeResponseDto>();

    private async Task FetchAttendeesAsync(CancellationToken cancellationToken = default)
    {
        IsLoading = true;

        var eventId = Dialog.Instance.Parameters.Get<Guid>("EventId");
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/events/{eventId}/attendees");
        var token = await protectedLocalStorage.GetAsync<string>(nameof(Constants.UserContextKey.AccessToken));
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token.Value);

        var response = await clientFactory
            .CreateClient(Constants.HttpClients.EventingApi.Name)
            .SendAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<IEnumerable<AttendeeResponseDto>>(cancellationToken);
            if (content == null)
            {
                toastService.ShowError(Constants.ErrorMessages.SomethingWentWrong);
            }
            else
            {
                Attendees = content;
            }
        }
        else
        {
            toastService.ShowError(Constants.ErrorMessages.SomethingWentWrong);
        }

        IsLoading = false;
    }

    private static string GetTooltip(AttendeeResponseDto attendee)
    {
        var comment = string.IsNullOrEmpty(attendee.Comment) ? "No comment" : attendee.Comment;
        var respondedAt = attendee.RespondedAt?.ToString("g") ?? "Not responded yet";
        return $"{comment}\nResponded at: {respondedAt}";
    }
}