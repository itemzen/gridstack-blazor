using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GridStack.Blazor;

public sealed partial class GsGrid : IAsyncDisposable
{
    [Inject] private IJSRuntime JsRuntime { get; set; } = null!;

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public GsGridOptions? Options { get; set; }

    [Parameter] public string? Style { get; set; }

    [Parameter] public EventCallback OnLoaded { get; set; }

    [Parameter] public EventCallback<GsWidgetListEventArgs> OnAdded { get; set; }

    [Parameter] public EventCallback<GsWidgetListEventArgs> OnChange { get; set; }

    [Parameter] public EventCallback OnDisable { get; set; }

    [Parameter] public EventCallback<GsWidgetEventArgs> OnDragStart { get; set; }

    [Parameter] public EventCallback<GsWidgetEventArgs> OnDrag { get; set; }

    [Parameter] public EventCallback<GsWidgetEventArgs> OnDragStop { get; set; }

    [Parameter] public EventCallback<GsWidgetDroppedEventArgs> OnDropped { get; set; }

    [Parameter] public EventCallback OnEnable { get; set; }

    [Parameter] public EventCallback<GsWidgetListEventArgs> OnRemoved { get; set; }

    [Parameter] public EventCallback<GsWidgetEventArgs> OnResizeStart { get; set; }

    [Parameter] public EventCallback<GsWidgetEventArgs> OnResize { get; set; }

    [Parameter] public EventCallback<GsWidgetEventArgs> OnResizeStop { get; set; }

    private IJSObjectReference? _module;
    private IJSObjectReference? _instance;
    private DotNetObjectReference<GsGrid>? _interopRef;

    private const string PackageName = "Itemzen.GridStack.Blazor";
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _module ??= await JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", $"./_content/{PackageName}/gridstack_interop.js");

            _interopRef = DotNetObjectReference.Create(this);
            _instance = await _module.InvokeAsync<IJSObjectReference>("init", Options, _interopRef);

            await OnLoaded.InvokeAsync();
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_interopRef != null)
        {
            _interopRef.Dispose();
            _interopRef = null;
        }

        if (_instance != null)
        {
            await _instance.DisposeAsync();
            _instance = null;
        }

        if (_module != null)
        {
            await _module.DisposeAsync();
            _module = null;
        }
    }

    public async Task<GsWidgetData> AddWidget(GsWidgetOptions? options = null)
    {
        return await _instance!.InvokeAsync<GsWidgetData>("addWidgetForBlazor", options ?? new GsWidgetOptions());
    }

    public async Task BatchUpdate(bool flag = true)
    {
        await _instance!.InvokeVoidAsync("batchUpdate", flag);
    }

    public async Task Compact(GsCompact mode = GsCompact.Compact, bool doSort = true)
    {
        var strMode = EnumToString(mode);
        await _instance!.InvokeVoidAsync("compact", strMode, doSort);
    }

    public async Task SetCellHeight(int val, bool? update = null)
    {
        await _instance!.InvokeVoidAsync("cellHeight", val, update);
    }

    public async Task<int> GetCellWidth()
    {
        return await _instance!.InvokeAsync<int>("cellWidth");
    }

    public async Task SetColumnCount(uint count, GsColumn layout = GsColumn.MoveScale)
    {
        var strLayout = EnumToString(layout);
        await _instance!.InvokeVoidAsync("column", count, strLayout);
    }

    public async Task Destroy(bool removeDom = true)
    {
        await _instance!.InvokeVoidAsync("destroy", removeDom);
    }

    public async Task Disable()
    {
        await _instance!.InvokeVoidAsync("disable");
    }

    public async Task Enable()
    {
        await _instance!.InvokeVoidAsync("enable");
    }

    public async Task EnableMove(bool isEnabled)
    {
        await _instance!.InvokeVoidAsync("enableMove", isEnabled);
    }

    public async Task EnableResize(bool isEnabled)
    {
        await _instance!.InvokeVoidAsync("enableResize", isEnabled);
    }

    public async Task SetFloat(bool? val = null)
    {
        await _instance!.InvokeVoidAsync("float", val);
    }

    public async Task<bool> GetFloat()
    {
        return await _instance!.InvokeAsync<bool>("float");
    }

    public async Task<int> GetCellHeight()
    {
        return await _instance!.InvokeAsync<int>("getCellHeight");
    }

    public async Task<GsCoordinate> GetCellFromPixel(uint top, uint left, bool? useOffset = null)
    {
        return await _instance!.InvokeAsync<GsCoordinate>("getCellFromPixel", new { top, left }, useOffset);
    }

    public async Task<uint> GetColumnCount()
    {
        return await _instance!.InvokeAsync<uint>("getColumn");
    }

    public async Task<IEnumerable<GsWidgetData>> GetGridItems()
    {
        return await _instance!.InvokeAsync<IEnumerable<GsWidgetData>>("getGridItemsForBlazor");
    }

    public async Task<uint> GetMargin()
    {
        return await _instance!.InvokeAsync<uint>("getMargin");
    }

    public async Task<bool> IsAreaEmpty(uint x, uint y, uint width, uint height)
    {
        return await _instance!.InvokeAsync<bool>("isAreaEmpty", x, y, width, height);
    }

    public async Task Load(IEnumerable<GsWidgetOptions> layout, bool? addAndRemove = null)
    {
        await _instance!.InvokeVoidAsync("load", layout, addAndRemove);
    }

    public async Task<GsWidgetData> MakeWidget(string id)
    {
        return await _instance!.InvokeAsync<GsWidgetData>("makeWidgetById", id);
    }

    public async Task SetMargin(uint value)
    {
        await _instance!.InvokeVoidAsync("margin", value);
    }

    public async Task SetMargin(string value)
    {
        await _instance!.InvokeVoidAsync("margin", value);
    }

    public async Task SetMovable(string id, bool val)
    {
        await _instance!.InvokeVoidAsync("movableById", id, val);
    }

    public async Task RemoveWidget(string id, bool removeDom = true, bool triggerEvent = true)
    {
        await _instance!.InvokeVoidAsync("removeWidgetById", id, removeDom, triggerEvent);
    }

    public async Task RemoveAll(bool? removeDom = null)
    {
        await _instance!.InvokeVoidAsync("removeAll", removeDom);
    }

    public async Task SetResizable(string id, bool val)
    {
        await _instance!.InvokeVoidAsync("resizableById", id, val);
    }

    public async Task ResizeToContent(string id, bool useAttrSize = false)
    {
        await _instance!.InvokeVoidAsync("resizeToContentById", id, useAttrSize);
    }

    public async Task Save(bool? saveContent)
    {
        await _instance!.InvokeVoidAsync("save", saveContent);
    }

    public async Task SetAnimation(bool doAnimate)
    {
        await _instance!.InvokeVoidAsync("setAnimation", doAnimate);
    }

    public async Task SetStatic(bool staticValue)
    {
        await _instance!.InvokeVoidAsync("setStatic", staticValue);
    }

    public async Task Update(string id, GsWidgetOptions opts)
    {
        await _instance!.InvokeVoidAsync("updateById", id, opts);
    }

    public async Task<bool> WillItFit(GsWidgetOptions opts)
    {
        return await _instance!.InvokeAsync<bool>("willItFit", opts);
    }

    [JSInvokable]
    public Task AddedFired(GsWidgetData[] widgets)
    {
        return OnAdded.InvokeAsync(new GsWidgetListEventArgs(widgets));
    }

    [JSInvokable]
    public Task ChangeFired(GsWidgetData[] widgets)
    {
        return OnChange.InvokeAsync(new GsWidgetListEventArgs(widgets));
    }

    [JSInvokable]
    public Task DisableFired()
    {
        return OnDisable.InvokeAsync();
    }

    [JSInvokable]
    public Task DragStartFired(GsWidgetData widget)
    {
        return OnDragStart.InvokeAsync(new GsWidgetEventArgs(widget));
    }

    [JSInvokable]
    public Task DragFired(GsWidgetData widget)
    {
        return OnDrag.InvokeAsync(new GsWidgetEventArgs(widget));
    }

    [JSInvokable]
    public Task DragStopFired(GsWidgetData widget)
    {
        return OnDragStop.InvokeAsync(new GsWidgetEventArgs(widget));
    }

    [JSInvokable]
    public Task DroppedFired(GsWidgetData previousWidget, GsWidgetData newWidget)
    {
        return OnDropped.InvokeAsync(new GsWidgetDroppedEventArgs(previousWidget, newWidget));
    }

    [JSInvokable]
    public Task EnableFired()
    {
        return OnEnable.InvokeAsync();
    }

    [JSInvokable]
    public Task RemovedFired(GsWidgetData[] widgets)
    {
        return OnRemoved.InvokeAsync(new GsWidgetListEventArgs(widgets));
    }

    [JSInvokable]
    public Task ResizeStartFired(GsWidgetData widget)
    {
        return OnResizeStart.InvokeAsync(new GsWidgetEventArgs(widget));
    }

    [JSInvokable]
    public Task ResizeFired(GsWidgetData widget)
    {
        return OnResize.InvokeAsync(new GsWidgetEventArgs(widget));
    }

    [JSInvokable]
    public Task ResizeStopFired(GsWidgetData widget)
    {
        return OnResizeStop.InvokeAsync(new GsWidgetEventArgs(widget));
    }

    private static string EnumToString<T>(T type) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T must be an enumerated type");
        }

        var fieldInfo = type.GetType().GetField(type.ToString()!);
        var description = (DescriptionAttribute?)fieldInfo?.GetCustomAttribute(typeof(DescriptionAttribute), false);

        if (description == null)
        {
            throw new ArgumentException("Description attribute is missing");
        }

        return description.Description;
    }
}