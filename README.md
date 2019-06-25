# SimpleImageCharts
This is a simple charting library for rendering charts as images. 

# Install 

.NET Standard 2.0

# Available Charts
1. [Pie Chart](#1-pie-chart)
2. [Donut Chart](#2-donut-chart)
3. [Bar Chart](#3-bar-chart)
4. [Stacked Bar Chart](#4-stacked-bar-chart)
5. [Double Axis Bar Chart](#5-double-axis-bar-chart)
6. [Column Chart](#6-column-chart)
7. [Radar Chart](#7-radar-chart)

## 1. Pie Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/pie.jpg" />

Create sample data:
```csharp
private static PieEntry[] CreatePieEntries()
{
    var rand = new Random();
    var entries = new PieEntry[10];
    for (int i = 0; i < entries.Length; i++)
    {
        entries[i] = new PieEntry
        {
            Value = (float)rand.Next(10, 40) / 10,
            Color = Color.FromArgb(rand.Next(0, 200), rand.Next(0, 200), rand.Next(0, 200)),
            Label = "Data " + i
        };
    }

    return entries;
}
```
Create chart:
```csharp
PieEntry[] entries = CreatePieEntries();

var chart = new PieChart
{
    Width = 300,
    Height = 600,
    Entries = entries
};

var bitmap = chart.CreateImage();
```

## 2. Donut Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/donut.jpg" />

```csharp
PieEntry[] entries = CreatePieEntries();

var chart = new PieChart
{
    Width = 300,
    Height = 600,
    Entries = entries,
    IsDonut = true // default: false
};

var bitmap = chart.CreateImage();
```

## 3. Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/BarChart.jpg" />

```csharp
var chart = new BarChart
{
    Width = 600,
    Height = 300,
    Categories = new[] { "Product A", "Product B", "Product C" },
    DataSets = new[]
    {
        new BarSeries
        {
            Label = "Green",
            Color = Color.Green,
            Data = new[] { -5f, 10f, 15f },
        },
        new BarSeries
        {
            Label = "Red",
            Color = Color.Red,
            Data = new[] { 1f, -2f, 3f },
        }
        ,
        new BarSeries
        {
            Label = "Blue",
            Color = Color.Blue,
            Data = new[] { 5f, 20f, -13f },
        }
    }
};

var bitmap = chart.CreateImage();
```
## 4. Stacked Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/StackedBarChart.jpg" />

```csharp
var chart = new BarChart
{
    Width = 600,
    Height = 300,
    IsStacked = true,
    FormatAxisValue = "{0:0;0}", // force positive values
    FormatBarValue = "{0:0;0}",
    Categories = new[] { "Product A", "Product B", "Product C", "Product A", "Product B", "Product C", "Product A", "Product B", "Product C" },
    DataSets = new[]
    {
        new BarSeries
        {
            Label = "Yesterday",
            Color = Color.Green,
            Data = new[] { -5f, -10f, -1f , -5f, -10f, -1f , -5f, -10f, -1f },
        },
        new BarSeries
        {
            Label = "Today",
            Color = Color.Red,
            Data = new[] { 10f, 20f, 5f, 10f, 20f, 5f, 10f, 20f, 5f },
        }
    }
};

var bitmap = chart.CreateImage();
```

## 5. Double Axis Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/DoubleAxisBarChart.jpg" />

```csharp
var chart = new DoubleAxisBarChart
{
    Width = 600,
    Height = 300,
    FormatBarValue = "{0}%",
    Categories = new[] { "Product A", "Product B", "Product C", "Product D", "Product E", "Product F" },
    FirstDataSet = new DoubleAxisBarSeries 
    { 
        Color = Color.Green,
        Data = new[] { 5f, 10f, 5f, 1f, 12f, 7f },
    },
    SecondDataSet = new DoubleAxisBarSeries
    {
        Color = Color.Red,
        Data = new[] { 15f, 10f, 15f, 8f, 2f, 14f },
    }
};

var bitmap = chart.CreateImage();
```

## 6. Column Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/ColumnChart.jpg" />

```csharp
var categories = new[] { "A", "Product B", "Product C", "Product D", "Product E" };
var rand = new Random();
var datasets = new ColumnSeries[4];
for (int i = 0; i < datasets.Length; i++)
{
    var data = new float[categories.Length];
    for (int j = 0; j < categories.Length; j++)
    {
        data[j] = rand.Next(20) - 10;
    }

    var dataset = new ColumnSeries
    {
        Color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)),
        Data = data
    };
    datasets[i] = dataset;
}

var chart = new ColumnChart
{
    Width = 600,
    Height = 300,
    Categories = categories,
    DataSets = datasets
};

var bitmap = chart.CreateImage();
```
## 7. Radar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/RadarChart.jpg" />

```csharp
var random = new Random();
var categories = new[] { "Eating", "Sleeping", "Doing Nothing", "Playing", "Relaxing", "Watching" };
var chart = new RadarChart
{
    Width = 600,
    Height = 300,
    Categories = categories,
    DataSets = new[]
    {
        new RadarChartSeries
        {
            Label = "My Life",
            Color = Color.LightCoral,
            Data = GenerateRandomArray(random, categories.Length, 10, 60),
        },
        new RadarChartSeries
        {
            Label = "My Wife Life",
            Color = Color.LightBlue,
            Data = GenerateRandomArray(random, categories.Length, 10, 70),
        }
    }
};

var bitmap = chart.CreateImage();
```