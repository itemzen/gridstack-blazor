# GridStack.Blazor

Blazor wrapper for the [gridstack.js](https://gridstackjs.com/) library, heavily based on the [BlazorGridStack](https://github.com/decelis/BlazorGridStack) wrapper.

## Installation

### NuGet

```bash
dotnet add package GridStack.Blazor
```

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

### Imports

Add a reference to the relevant namespaces in the top-level `_Imports.razor` file

```razor
@using GridStack.Blazor
@using GridStack.Blazor.Models
```

## Usage

The wrapper adds two components: `GsGrid` and `GsWrapper`.

```razor
<GsGrid Options="...">
    <GsWidget Options="..." />
    <GsWidget />
</GsGrid>
```

The demo project contains additional details.
