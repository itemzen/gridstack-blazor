export function init(gridOptions, interopReference) {

    const grid = window.GridStack.init(gridOptions);

    /*
     * events (https://github.com/gridstack/gridstack.js/blob/master/doc/README.md#events)
     */

    // Called when widgets are being added to a grid (Event, GridStackNode[])
    grid.on("added",
        async (event, items) => {
            await interopReference.invokeMethodAsync("AddedFired", items.map(i => {
                return gsNodeToWidgetData(i)
            }));
        });

    // Occurs when widgets change their position/size due to constrain or direct changes.
    // (Event, GridStackNode[])
    grid.on("change",
        async (event, items) => {
            await interopReference.invokeMethodAsync("ChangeFired", items.map(i => {
                return gsNodeToWidgetData(i)
            }));
        });

    // Triggered when grid is disabled (Event)
    grid.on("disable",
        async (_) => {
            await interopReference.invokeMethodAsync("DisableFired");
        });

    // Called when grid item is starting to be dragged (Event, GridItemHTMLElement)
    grid.on("dragstart",
        async (event, el) => {
            await interopReference.invokeMethodAsync("DragStartFired", gsItemHTMLElementToWidgetData(el));
        });

    // Called while grid item is being dragged, for each new row/column value (not every pixel)
    // (Event, GridItemHTMLElement)
    grid.on("drag",
        async (event, el) => {
            await interopReference.invokeMethodAsync("DragFired", gsItemHTMLElementToWidgetData(el));
        });

    // Called after the user is done moving the item, with updated DOM attributes.
    // (Event, GridItemHTMLElement)
    grid.on("dragstop",
        async (event, el) => {
            await interopReference.invokeMethodAsync("DragStopFired", gsItemHTMLElementToWidgetData(el));
        });

    // Called when an item has been dropped and accepted over a grid. 
    // If the item came from another grid, the previous widget node info will also be sent (but dom item long gone).
    // (Event, GridStackNode, GridStackNode)
    grid.on("dropped",
        async (event, previousEl, newEl) => {
            await interopReference.invokeMethodAsync("DroppedFired", gsNodeToWidgetData(previousEl), gsNodeToWidgetData(newEl));
        });

    // Triggered when grid is enabled (Event)
    grid.on("enable",
        async (_) => {
            await interopReference.invokeMethodAsync("EnableFired");
        });

    // Called when items are being removed from the grid (Event, GridStackNode[])
    grid.on("removed",
        async (event, items) => {
            await interopReference.invokeMethodAsync("RemovedFired", items.map(i => {
                return gsNodeToWidgetData(i)
            }));
        });

    // Called before the user starts resizing an item (Event, GridItemHTMLElement)
    grid.on("resizestart",
        async (event, el) => {
            await interopReference.invokeMethodAsync("ResizeStartFired", gsItemHTMLElementToWidgetData(el));
        });

    // Called while grid item is being resized, for each new row/column value (not every pixel)
    // (Event, GridItemHTMLElement)
    grid.on("resize",
        async (event, el) => {
            await interopReference.invokeMethodAsync("ResizeFired", gsItemHTMLElementToWidgetData(el));
        });

    // Called after the user is done resizing the item, with updated DOM attributes.
    // (Event, GridItemHTMLElement)
    grid.on("resizestop",
        async (event, el) => {
            await interopReference.invokeMethodAsync("ResizeStopFired", gsItemHTMLElementToWidgetData(el));
        });

    /*
     * api methods (https://github.com/gridstack/gridstack.js/blob/master/doc/README.md#api)
     */

    // Creates new widget and returns it
    grid.addWidgetForBlazor = (widgetOptions) => {
        return gsItemHTMLElementToWidgetData(grid.addWidget(widgetOptions));
    }

    grid.getGridItemsForBlazor = () =>
    {
        return grid.getGridItems().map(i => { return gsItemHTMLElementToWidgetData(i) });
    }

    grid.makeWidgetById = (id) =>
    {
        grid.makeWidget(document.getElementById(id));
    }

    grid.movableById = (id, val) =>
    {
        grid.movable(document.getElementById(id), val);
    }

    grid.removeWidgetById = (id, removeDOM, triggerEvent) =>
    {
        grid.removeWidget(document.getElementById(id), removeDOM, triggerEvent);
    }

    grid.resizableById = (id, val) =>
    {
        grid.resizable(document.getElementById(id), val);
    }

    grid.resizeToContentById = (id, useAttrSize) => 
    {
        grid.resizeToContent(document.getElementById(id), useAttrSize);
    }
    
    grid.updateById = (id, opts) =>
    {
        grid.update(document.getElementById(id), opts);
    }
    
    return grid;
}

/**
 * GridStackPosition < GridStackWidget < GridStackNode
 *
 * A subset of the properties of the GridStackNode object passed as
 * an argument are mapped to an object matching the GsWidgetData signature.
 */
function gsNodeToWidgetData(gsNode) {
    return {
        // GridStackPosition: x, y, width, height
        x: gsNode.x,
        y: gsNode.y,
        h: gsNode.h,
        w: gsNode.w,
        // GridStackWidget: value for `gs-id` stored on the widget
        id: gsNode.id,
        // GridStackNode: el = pointer back to HTML element
        content: gsNode.el ? gsNode.el.innerHTML : null,
        className: gsNode.el ? gsNode.el.className : null
    }
}

/**
 * HTMLElement < GridItemHTMLElement
 *
 * A subset of the properties of the GridItemHTMLElement object passed as
 * an argument are mapped to an object matching the GsWidgetData signature.
 */
function gsItemHTMLElementToWidgetData(gsElement) {
    return {
        x: parseInt(gsElement.getAttribute("gs-x")),
        y: parseInt(gsElement.getAttribute("gs-y")),
        h: parseInt(gsElement.getAttribute("gs-h")),
        w: parseInt(gsElement.getAttribute("gs-w")),
        id: gsElement.getAttribute("gs-id"),
        content: gsElement.querySelector(".grid-stack-item-content").innerHTML,
        className: gsElement.className
    }
}