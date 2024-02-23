namespace GridStack.Blazor.Models;

public sealed class GsWidgetListEventArgs : EventArgs
{
    public static GsWidgetListEventArgs New(IEnumerable<GsWidgetData> widgets)
    {
        return new GsWidgetListEventArgs(widgets);
    }

    private GsWidgetListEventArgs(IEnumerable<GsWidgetData> widgets)
    {
        Widgets = widgets;
    }

    public IEnumerable<GsWidgetData> Widgets { get; set; }
}