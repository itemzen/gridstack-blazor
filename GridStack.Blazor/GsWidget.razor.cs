using GridStack.Blazor.Models;
using Microsoft.AspNetCore.Components;

namespace GridStack.Blazor;

public partial class GsWidget : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    
    [Parameter] public GsWidgetOptions? Options { get; set; }
}