using System.Text.Json.Serialization;

namespace Eventing.Web.Components.Features.Attendee.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<RsvpResponse>))]
public enum RsvpResponse
{
    Pending,
    Accepted,
    Declined,
    Maybe
}