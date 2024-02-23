using System.Text.Json.Serialization;

namespace GridStack.Blazor.Models;

public sealed record GsWidgetData
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }
    
    [JsonPropertyName("h")]
    public int? H { get; set; }
    
    [JsonPropertyName("w")]
    public int? W { get; set; }
    
    [JsonPropertyName("x")]
    public int X { get; set; }
    
    [JsonPropertyName("y")]
    public int Y { get; set; }
    
    [JsonPropertyName("className")]
    public string? ClassName { get; set; }
    
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    public override string ToString()
    {
        var id = string.IsNullOrEmpty(Id) ? "null" : Id;
        return $"id: {id} (x:{X}, y:{Y}) (w:{W}, h:{H})";
    }
}