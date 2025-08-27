using Eventing.Web.Ui.Features.Attendee.Enums;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Eventing.Web.Ui.Features.Attendee.Button;

public partial class RsvpButton : ComponentBase
{
    [Parameter] public RsvpResponse RsvpResponse { get; set; }

    private Color GetColor() => RsvpResponse switch
    {
        RsvpResponse.Pending => Color.Inherit,
        RsvpResponse.Accepted => Color.Success,
        RsvpResponse.Declined => Color.Error,
        RsvpResponse.Maybe => Color.Warning,
        _ => throw new ArgumentOutOfRangeException()
    };
}