using Eventing.Web.Components.Features.Attendee.Enum;
using Microsoft.AspNetCore.Components;

namespace Eventing.Web.Components.Features.Attendee;

public partial class RsvpRespondButton : ComponentBase
{
    [Parameter]
    public RsvpResponse RsvpResponse { get; set; }
    
    private async Task RespondAsync(RsvpResponse response)
    {
        RsvpResponse = response;
    }
}