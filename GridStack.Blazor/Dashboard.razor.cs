using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GridStack.Blazor;

public partial class Dashboard : IAsyncDisposable
{
    [Inject] private IJSRuntime JsRuntime { get; set; } = null!;

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public DashboardOptions? Options { get; set; }

    [Parameter] public string? Style { get; set; }

    private IJSObjectReference? _module;
    private IJSObjectReference? _instance;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _module ??= await JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", $"./_content/{Assembly.GetExecutingAssembly().GetName().Name}/gridstack_interop.js");

            var interopRef = DotNetObjectReference.Create(this);
            _instance = await _module.InvokeAsync<IJSObjectReference>("init", Options);
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_module != null)
        {
            await _module.DisposeAsync();
            _module = null;
        }
    }

    public async Task AddWidget()
    {
        await _instance!.InvokeAsync<Widget>("addWidgetForBlazor");
    }
}