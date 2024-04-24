namespace GridStack.Blazor;

public sealed class GsWidgetEventArgs
{
    internal GsWidgetEventArgs(GsWidgetData widget)
    {
        Widget = widget;
    }

    public GsWidgetData Widget { get; private set; }
}