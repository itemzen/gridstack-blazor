using System.ComponentModel;

namespace GridStack.Blazor;

public enum GsColumn
{
    [Description("list")] List,
    [Description("compact")] Compact,
    [Description("moveScale")] MoveScale,
    [Description("move")] Move,
    [Description("scale")] Scale,
    [Description("none")] None
}