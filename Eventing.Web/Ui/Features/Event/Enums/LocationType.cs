using System.Text.Json.Serialization;

namespace Eventing.Web.Ui.Features.Event.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<LocationType>))]
public enum LocationType
{
    Physical,
    Virtual
}