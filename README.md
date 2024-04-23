# Itemzen.GridStack.Blazor

Blazor wrapper for the [gridstack.js](https://gridstackjs.com/) library.

Credits go to the [BlazorGridStack](https://github.com/decelis/BlazorGridStack) project,
on which this wrapper took inspiration.

## Installation

### NuGet

```bash
dotnet add package Itemzen.GridStack.Blazor
```

The version of the nuget package matches the gridstack version against which the wrapper was created,
including a version suffix indicating the wrapper release number. For example, `v10.1.0-r2` indicates the
second release of the wrapper for version `10.1.0` of the gridstack library.

Note that it is in general fine to use/include a different (minor) gridstack version in your project,
especially bugfix releases, but if things don't work as expected it might be best to try and match 
the gridstack version exactly.

### index.html

Download the gridstack files from npm

```bash
npm install --save gridstack
```

Copy the relevant files over from the `node_modules/gridstack/dist` to your Blazor project

```bash
wwwroot/lib/gridstack-all.js
wwwroot/lib/gridstack.min.css
wwwroot/lib/gridstack-extra.min.css
```

Add the following lines in `wwwroot/index.html`

```html
<head>
    ...
    <link href="lib/gridstack.min.css" rel="stylesheet" />
    <link href="lib/gridstack-extra.min.css" rel="stylesheet" />
</head>
<body>
    ...
    <script src="lib/gridstack-all.js"></script>
</body>
```

Note that the `gridstack-extra.min.css` file is only needed if you intend to change the default number
of grid columns from 12 to a lower value.

### Imports

Add a reference to the relevant namespaces in the top-level `_Imports.razor` file of your project

```razor
@using GridStack.Blazor
@using GridStack.Blazor.Models
```

## Usage

The wrapper adds two components: `GsGrid` and `GsWidget`.

```razor
<GsGrid Options="...">
    <GsWidget Options="...">
        <div>The widget layout</div>
    </GsWidget>
</GsGrid>
```

The widgets can be added to the grid using markup (as shown above), or programatically
using the GsGrid API.

The [demo project](https://github.com/itemzen/gridstack-blazor/tree/main/GridStack.Blazor.Demo) contains additional details.

## Acknowledgements

Brought to you by the [itemzen](https://itemzen.com) team.
