using System.Text.Json.Serialization;

namespace GridStack.Blazor.Models;

public sealed record GsCoordinate
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }
}