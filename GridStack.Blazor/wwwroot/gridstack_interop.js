
export function init(options) {
    
    const grid = window.GridStack.init(options);

    grid.addWidgetForBlazor = () => {
        grid.addWidget();
    }
    
    return grid;
}