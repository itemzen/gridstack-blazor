using System.Text.Json.Serialization;

namespace GridStack.Blazor;

/**
 * GridStackOptions
 * See https://github.com/gridstack/gridstack.js/blob/master/src/types.ts#L116
 */
public sealed record GsGridOptions
{
    // TODO - acceptWidgets
    
    /// <summary>
    /// Does not apply to non-resizable widgets. Possible values:
    /// - false: the resizing handles are only shown while hovering over a widget
    /// - true: the resizing handles are always shown
    /// - mobile: if running on a mobile device, default to `true`, else `false`
    /// Mobile is the default value. Given that, only override with true or false is needed.
    /// </summary>
    [JsonPropertyName("alwaysShowResizeHandle")]
    public bool? AlwaysShowResizeHandle { get; set; }

    /// <summary>
    /// Turns animation on/off, default true
    /// </summary>
    [JsonPropertyName("animate")]
    public bool? Animate { get; set; }

    /// <summary>
    /// If false gridstack will not initialize existing items, default true
    /// </summary>
    [JsonPropertyName("auto")] 
    public bool? Auto { get; set; }

    /// <summary>
    /// One cell height (default is 'auto'). Can be:
    /// - an integer (px)
    /// - a string (ex: '100px', '10em', '10rem'). Note: % doesn't work right - see demo/cell-height.html
    /// - 0, in which case the library will not generate styles for rows. Everything must be defined in your own CSS files.
    /// - 'auto' - height will be calculated for square cells (width / column) and updated live as you resize the window (also see `cellHeightThrottle`)
    /// - 'initial' - similar to 'auto' (start at square cells) but stay that size during window resizing.
    /// </summary>
    [JsonPropertyName("cellHeight")]
    public object? CellHeight { get; set; }
    
    /// <summary>
    /// Throttle time delay (in ms) used when cellHeight='auto' to improve performance vs usability (default?: 100).
    /// A value of 0 will make it instant at a cost of re-creating the CSS file at ever window resize event!
    /// </summary>
    [JsonPropertyName("cellHeightThrottle")]
    public uint? CellHeightThrottle { get; set; }

    /// <summary>
    /// Unit for cellHeight (default? 'px') which is set when a string cellHeight with a unit is passed (ex: '10rem')
    /// </summary>
    [JsonPropertyName("cellHeightUnit")]
    public string? CellHeightUnit { get; set; }

    // TODO - children

    /// <summary>
    /// Number of columns (default 12). Note: IF you change this, CSS also have to change.
    /// See https://github.com/gridstack/gridstack.js#change-grid-columns.
    /// Note: for nested grids, it is recommended to use 'auto' which will always match the container
    /// grid-item current width (in column) to keep inside and outside items always to same.
    /// Flag is not supported for regular non-nested grids.
    /// </summary>
    [JsonPropertyName("column")]
    public object? Column { get; set; }
    
    /// <summary>
    /// Responsive column layout for width:column behavior. See <see cref="GsResponsive"/>.
    /// </summary>
    [JsonPropertyName("columnOpts")]
    public GsResponsive? ColumnOpts { get; set; }
    
    /// <summary>
    /// Additional class on top of '.grid-stack' (which is required for our CSS) to differentiate this instance.
    /// Note: only used by addGrid(), else your element should have the needed class.
    /// </summary>
    [JsonPropertyName("class")]
    public string? Class { get; set; }
    
    /// <summary>
    /// Disallows dragging of widgets (default false)
    /// </summary>
    [JsonPropertyName("disableDrag")]
    public bool? DisableDrag { get; set; }

    /// <summary>
    /// Disallows resizing of widgets (default false)
    /// </summary>
    [JsonPropertyName("disableResize")]
    public bool? DisableResize { get; set; }

    /// <summary>
    /// Allows to override UI draggable options.
    /// (default: { handle?: '.grid-stack-item-content', appendTo?: 'body' })
    /// </summary>
    [JsonPropertyName("draggable")]
    public GsDraggableOptions? Draggable { get; set; }

    // TODO - engineClass
    
    /// <summary>
    /// Enable floating widgets (default false).
    /// Floating widgets can be placed anywhere in the y-axis on the grid.
    /// See example http://gridstack.github.io/gridstack.js/demo/float.html
    /// </summary>
    [JsonPropertyName("float")]
    public bool? Float { get; set; }
    
    /// <summary>
    /// Draggable handle selector (default '.grid-stack-item-content')
    /// </summary>
    [JsonPropertyName("handle")]
    public string? Handle { get; set; }

    /// <summary>
    /// Draggable handle class (e.g. 'grid-stack-item-content').
    /// If set 'handle' is ignored (default: null)
    /// </summary>
    [JsonPropertyName("handleClass")]
    public string? HandleClass { get; set; }

    /// <summary>
    /// Additional widget class (default: 'grid-stack-item')
    /// </summary>
    [JsonPropertyName("itemClass")]
    public string? ItemClass { get; set; }

    /// <summary>
    /// Gap between grid item and content (default: 10).
    /// This will set all 4 sides and support the CSS formats below
    /// - a string with possible units (ex: '2em', '20px', '2rem')
    /// - a string with space separated values (ex: '5px 10px 0 20px' for all 4 sides, or '5em 10em' for top/bottom and left/right pairs like CSS).
    /// Note: all sides must have same units (last one wins, default px)
    /// </summary>
    [JsonPropertyName("margin")]
    public string? Margin { get; set; }

    /// <summary>
    /// Unit for margin (default: 'px') set when `margin` is set as string with unit (ex: 2rem).
    /// </summary>
    [JsonPropertyName("marginUnit")]
    public string? MarginUnit { get; set; }

    /// <summary>
    ///  Maximum rows amount. Default is 0 which means no maximum rows.
    /// </summary>
    [JsonPropertyName("maxRow")]
    public uint? MaxRow { get; set; }
    
    /// <summary>
    /// Minimum rows amount. Default is `0`. You can also do this with `min-height` CSS attribute
    /// on the grid div in pixels, which will round to the closest row.
    /// </summary>
    [JsonPropertyName("minRow")]
    public uint? MinRow { get; set; }

    /// <summary>
    /// If you are using a nonce-based Content Security Policy, pass your nonce here and
    /// GridStack will add it to the 'style' elements it creates.
    /// </summary>
    [JsonPropertyName("nonce")]
    public string? Nonce { get; set; }

    /// <summary>
    /// Class for placeholder (default: 'grid-stack-placeholder')
    /// </summary>
    [JsonPropertyName("placeholderClass")]
    public string? PlaceholderClass { get; set; }

    /// <summary>
    /// Placeholder default content (default: '')
    /// </summary>
    [JsonPropertyName("placeholderText")]
    public string? PlaceholderText { get; set; }
    
    // TODO - resizable
    
    // TODO - removable
    
    // TODO - removableOptions

    /// <summary>
    /// Fix grid number of rows. This is a shortcut of writing `minRow:N, maxRow:N`.
    /// (default `0` no constraints)
    /// </summary>
    [JsonPropertyName("row")]
    public uint? Row { get; set; }

    /// <summary>
    /// If true turns grid to RTL. Possible values are true, false, 'auto' (default: 'auto').
    /// </summary>
    [JsonPropertyName("rtl")]
    public bool? Rtl { get; set; }

    /// <summary>
    /// Set to true if all grid items (by default, but item can also override) height should
    /// be based on content size instead of WidgetItem.h to avoid v-scrollbars.
    /// Note: this is still row based, not pixels,
    /// so it will use ceil(getBoundingClientRect().height / getCellHeight()).
    /// </summary>
    [JsonPropertyName("sizeToContent")]
    public bool? SizeToContent { get; set; }

    /// <summary>
    /// Makes grid static (default: false). If `true` widgets are not movable/resizable.
    /// You don't even need draggable/resizable. A CSS class 'grid-stack-static' is also
    /// added to the element.
    /// </summary>
    [JsonPropertyName("staticGrid")]
    public bool? StaticGrid { get; set; }

    /// <summary>
    /// If `true` will add style element to `head` otherwise will add it to element's
    /// parent node (default `false`). 
    /// </summary>
    [JsonPropertyName("styleInHead")]
    public bool? StyleInHead { get; set; }
    
    // TODO - subGridOpts
    
    //  TODO - subGridDynamic
}

public sealed record GsDraggableOptions
{
    [JsonPropertyName("appendTo")]
    public string? AppendTo { get; set; }
    
    [JsonPropertyName("handle")]
    public string? Handle { get; set; }
    
    [JsonPropertyName("scroll")]
    public bool? Scroll { get; set; }
}