using System.Text.Json.Serialization;

namespace GridStack.Blazor;

/// <summary>
/// Describes the responsive options of the grid.
/// </summary>
/// <remarks>
/// Make sure to have correct extra CSS to support this.
/// </remarks>
public sealed record GsResponsive
{
    /// <summary>
    /// Wanted width to maintain (+-50%) to dynamically pick a column count.
    /// </summary>
    /// <remarks>
    /// Make sure to have correct extra CSS to support this.
    /// </remarks>
    [JsonPropertyName("columnWidth")]
    public uint? ColumnWidth { get; set; }
    
    /// <summary>
    /// Maximum number of columns allowed (default: 12).
    /// </summary>
    /// <remarks>
    /// Make sure to have correct extra CSS to support this.
    /// </remarks>
    [JsonPropertyName("columnMax")]
    public uint? ColumnMax { get; set; }
    
    /// <summary>
    /// Explicit width:column breakpoints instead of automatic using <see cref="ColumnWidth"/>.
    /// </summary>
    /// <remarks>
    /// Make sure to have correct extra CSS to support this.
    /// </remarks>
    [JsonPropertyName("breakpoints")]
    public List<GsBreakpoint>? Breakpoints { get; set; }
    
    /// <summary>
    /// Specify if breakpoints are for window size or grid size (default: false = grid size)
    /// </summary>
    [JsonPropertyName("breakpointForWindow")]
    public bool BreakpointForWindow { get; set; }
    
    /// <summary>
    /// Global re-layout mode when changing columns.
    /// </summary>
    [JsonPropertyName("layout")]
    public GsColumn? Layout { get; set; } 
}

public sealed record GsBreakpoint
{
    /// <summary>
    /// Width for the breakpoint to trigger after.
    /// </summary>
    [JsonPropertyName("w")]
    public uint W { get; set; }
    
    /// <summary>
    /// Column count for this breakpoint at the width specified in <see cref="W"/>.
    /// </summary>
    [JsonPropertyName("c")]
    public uint C { get; set; }
    
    /// <summary>
    /// Global re-layout mode when changing columns.
    /// </summary>
    [JsonPropertyName("layout")]
    public GsColumn? Layout { get; set; } 
}