namespace GridStack.Blazor.Models;

public sealed class GsWidgetEventArgs
{
    public static GsWidgetEventArgs New(GsWidgetData widget)
    {
        return new GsWidgetEventArgs(widget);
    }

    private GsWidgetEventArgs(GsWidgetData widget)
    {
        Widget = widget;
    }

    public GsWidgetData Widget { get; set; }
}