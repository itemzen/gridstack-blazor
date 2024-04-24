using System.Text.Json.Serialization;

namespace GridStack.Blazor;

public sealed record GsWidgetData
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }
    
    [JsonPropertyName("h")]
    public uint H { get; set; }
    
    [JsonPropertyName("w")]
    public uint W { get; set; }
    
    [JsonPropertyName("x")]
    public uint X { get; set; }
    
    [JsonPropertyName("y")]
    public uint Y { get; set; }
    
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