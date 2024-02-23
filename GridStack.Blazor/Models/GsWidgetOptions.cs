using System.Text.Json.Serialization;

namespace GridStack.Blazor.Models;

/**
 * Any property on GridStackWidget can be used as an option
 * See https://github.com/gridstack/gridstack.js/blob/master/src/types.ts#L318
 */
public sealed record GsWidgetOptions
{
    /// <summary>
    /// Widget position x (default: 0)
    /// </summary>
    public uint? X { get; set; }

    /// <summary>
    /// Widget position y (default: 0)
    /// </summary>
    public uint? Y { get; set; }

    /// <summary>
    /// Widget dimension width (default: 1)
    /// </summary>
    public uint? W { get; set; } = 1;

    /// <summary>
    /// Widget dimension height (default: 1)
    /// </summary>
    public uint? H { get; set; } = 1;

    /// <summary>
    /// If true then x, y parameters will be ignored and widget
    /// will be places on the first available position (default: false)
    /// </summary>
    [JsonPropertyName("autoPosition")]
    public bool? AutoPosition { get; set; }

    /// <summary>
    /// Minimum width allowed during resize/creation (default: undefined = un-constrained)
    /// </summary>
    [JsonPropertyName("minW")]
    public uint? MinW { get; set; }

    /// <summary>
    /// Maximum width allowed during resize/creation (default: undefined = un-constrained)
    /// </summary>
    [JsonPropertyName("maxW")]
    public uint? MaxW { get; set; }

    /// <summary>
    /// Minimum height allowed during resize/creation (default: undefined = un-constrained)
    /// </summary>
    [JsonPropertyName("minH")]
    public uint? MinH { get; set; }

    /// <summary>
    /// Maximum height allowed during resize/creation (default: undefined = un-constrained)
    /// </summary>
    [JsonPropertyName("maxH")]
    public uint? MaxH { get; set; }

    /// <summary>
    /// Prevent direct resizing by the user (default: undefined = un-constrained)
    /// </summary>
    [JsonPropertyName("noResize")]
    public bool? NoResize { get; set; }

    /// <summary>
    /// Prevents direct moving by the user (default: undefined = un-constrained)
    /// </summary>
    [JsonPropertyName("noMove")]
    public bool? NoMove { get; set; }

    /// <summary>
    /// Same as noMove+noResize but also prevents being pushed by other
    /// widgets or api (default: undefined = un-constrained)
    /// Note: this property does not seem to have effect except when NoMove=true and NoResize=true as well.
    /// </summary>
    [JsonPropertyName("locked")]
    public bool? IsLocked { get; set; }

    /// <summary>
    /// Value for `gs-id` stored on the widget (default: undefined)
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// HTML to append inside as content
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    // TODO - sizeToContent

    // TODO - resizeToContentParent

    // TODO - subGridOpts
}