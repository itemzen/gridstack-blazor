namespace GridStack.Blazor.Models;

public sealed class GsWidgetDroppedEventArgs
{
    public static GsWidgetDroppedEventArgs New(GsWidgetData previousWidget, GsWidgetData newWidget)
    {
        return new GsWidgetDroppedEventArgs(previousWidget, newWidget);
    }

    private GsWidgetDroppedEventArgs(GsWidgetData previousWidget, GsWidgetData newWidget)
    {
        PreviousWidget = previousWidget;
        NewWidget = newWidget;
    }

    public GsWidgetData PreviousWidget { get; set; }

    public GsWidgetData NewWidget { get; set; }
}