namespace GridStack.Blazor;

public sealed class GsWidgetListEventArgs : EventArgs
{
    internal GsWidgetListEventArgs(IEnumerable<GsWidgetData> widgets)
    {
        Widgets = widgets;
    }

    public IEnumerable<GsWidgetData> Widgets { get; private set; }
}