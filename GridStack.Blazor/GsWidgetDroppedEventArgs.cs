namespace GridStack.Blazor;

public sealed class GsWidgetDroppedEventArgs
{
    internal GsWidgetDroppedEventArgs(GsWidgetData previousWidget, GsWidgetData newWidget)
    {
        PreviousWidget = previousWidget;
        NewWidget = newWidget;
    }

    public GsWidgetData PreviousWidget { get; private set; }

    public GsWidgetData NewWidget { get; private set; }
}