using Microsoft.AspNetCore.Components;

namespace GridStack.Blazor;

public partial class Widget : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
}