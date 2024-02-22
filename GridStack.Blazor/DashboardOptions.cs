using System.Text.Json.Serialization;

namespace GridStack.Blazor;

public sealed record DashboardOptions
{
    [JsonPropertyName("alwaysShowResizeHandle")]
    public bool? AlwaysShowResizeHandle { get; set; }

    [JsonPropertyName("animate")]
    public bool? Animate { get; set; }

    [JsonPropertyName("auto")] public bool? Auto { get; set; } = true;

    [JsonPropertyName("cellHeight")]
    public string? CellHeight { get; set; }
    
    [JsonPropertyName("cellHeightThrottle")]
    public int? CellHeightThrottle { get; set; }
    
    [JsonPropertyName("column")]
    public int? Column { get; set; }
    
    [JsonPropertyName("class")]
    public string? Class { get; set; }
    
    [JsonPropertyName("disableDrag")]
    public bool? DisableDrag { get; set; }
    
    [JsonPropertyName("disableOneColumnMode")]
    public bool? DisableOneColumnMode { get; set; }
    
    [JsonPropertyName("disableResize")]
    public bool? DisableResize { get; set; }
    
    [JsonPropertyName("dragIn")]
    public string? DragIn { get; set; }
}