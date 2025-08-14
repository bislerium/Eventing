using System.Text.Json.Serialization;

namespace Eventing.Web.Components.Features.Event.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<LocationType>))]
public enum LocationType
{
    Physical,
    Virtual
}