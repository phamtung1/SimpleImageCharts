# SimpleImageCharts
This is a simple charting library for rendering charts as images using GDI+. 

# Install 

.NET Standard 2.0

# Usage
After creating a chart instance, you just need to call:
```csharp
var image = chart.CreateImage();
```
# Available Charts
1. [Pie Chart](#1-pie-chart)
2. [Donut Chart](#2-donut-chart)
3. [Bar Chart](#3-bar-chart)
4. [Stacked Bar Chart](#4-stacked-bar-chart)
5. [Double Axis Bar Chart](#5-double-axis-bar-chart)
6. [100% Stacked Bar Chart](#6-100-stacked-bar-chart)
7. [Column Chart](#7-column-chart)
8. [100% Stacked Column Chart](#8-100-stacked-column-chart)
9. [Radar Chart](#9-radar-chart)
10. [Single Range Bar Chart](#10-single-range-bar-chart)


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
```

## 3. Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/BarChart.jpg" />

```csharp
var chart = new BarChart
{
    Legend = new LegendModel
    {
        Margin = new PointF(0, 40),
        VerticalAlign = VerticalAlign.Bottom,
        HorizontalAlign = HorizontalAlign.Center
    },
    ChartGridModel = new ChartGridModel
    {
        LineColor = Color.LightGreen
    },
    SubTitle = new SubTitleModel { Text = "AAAAAAA" },
    Size = size,
    Categories = new[] { "Product A", "Product B", "Product C" },
    DataSet = new[]
    {
        new DataSeries
        {
            Label = "LightBlue",
            Color = Color.LightBlue,
            Data = new[] { -5f, 10f, 15f },
        },
        new DataSeries
        {
            Label = "LightCoral",
            Color = Color.LightCoral,
            Data = new[] { 1f, -2f, 3f },
        }
        ,
        new DataSeries
        {
            Label = "LightGreen",
            Color = Color.LightGreen,
            Data = new[] { 5f, 20f, -13f },
        }
    }
};
```
## 4. Stacked Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/StackedBarChart.jpg" />

```csharp
var chart = new BarChart
{
    Legend = new LegendModel
    {
        Margin = new PointF(0, 50),
        VerticalAlign = VerticalAlign.Bottom
    },
    ChartGridModel = new ChartGridModel
    {
        LineColor = Color.LightGreen
    },
    BarSetting = new BarSettingModel
    {
        IsStacked = true,
        FormatValue = "{0:0;0}",
    },
    SubTitle = new SubTitleModel { Text = "Some random text" },
    Size = size,
    FormatAxisValue = "{0:0;0}", // force positive values
    Categories = new[] { "Product A", "Product B", "Product C", "Product A", "Product B", "Product C", "Product A", "Product B", "Product C" },
    DataSet = new[]
    {
        new DataSeries
        {
            Label = "Yesterday",
            Color = Color.LightBlue,
            Data = new[] { -5f, -10f, -1f , -5f, -10f, -1f , -5f, -10f, -1f },
        },
        new DataSeries
        {
            Label = "Today",
            Color = Color.LightCoral,
            Data = new[] { 10f, 20f, 5f, 10f, 20f, 5f, 10f, 20f, 5f },
        }
    }
};
```

## 5. Double Axis Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/DoubleAxisBarChart.jpg" />

```csharp
var chart = new DoubleAxisBarChart
{
    FormatBarValue = "{0}%",
    Size = size,
    Categories = new[] { "Product A", "Product B", "Product C", "Product D", "Product E", "Product F" },
    FirstDataSet = new DoubleAxisBarSeries
    {
        Label = "Income",
        Color = Color.LightBlue,
        Data = new[] { 5f, 10f, 5f, 1f, 12f, 7f },
    },
    SecondDataSet = new DoubleAxisBarSeries
    {
        Label = "Outcome",
        Color = Color.LightCoral,
        Data = new[] { 15f, 10f, 15f, 8f, 2f, 14f },
    }
};
```

## 6. 100% Stacked Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/StackedBar100Chart.jpg" />

```csharp
var chart = new StackedBar100Chart
{
    Legend = new LegendModel
    {
        Margin = new PointF(0, 40),
        VerticalAlign = VerticalAlign.Bottom,
        HorizontalAlign = HorizontalAlign.Center
    },
    SubTitle = new SubTitleModel { Text = "AAAAAAA" },
    Size = size,
    Categories = new[] { "Product A", "Product B", "Product C" },
    DataSet = new[]
    {
        new DataSeries
        {
            Label = "LightBlue",
            Color = Color.LightBlue,
            Data = new[] { 25f, 3f, 3f },
        },
        new DataSeries
        {
            Label = "LightCoral",
            Color = Color.LightCoral,
            Data = new[] { 25f, 3f, 2f },
        }
        ,
        new DataSeries
        {
            Label = "LightGreen",
            Color = Color.LightGreen,
            Data = new[] { 50f, 3f, 5f },
        }
    }
};
```

## 7. Column Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/ColumnChart.jpg" />

```csharp
var categories = new[] { "Product A", "Product B", "Product C", "Product D", "Product E" };
var rand = new Random();
var datasets = new ColumnSeries[3];
for (int i = 0; i < datasets.Length; i++)
{
    var data = new float[categories.Length];
    for (int j = 0; j < categories.Length; j++)
    {
        data[j] = rand.Next(30) - 10;
    }

    var dataset = new ColumnSeries
    {
        Color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)),
        Data = data
    };
    datasets[i] = dataset;
}

datasets[0].OffsetX = 10;
var chart = new ColumnChart
{
    ColumnSize = 30,
    Size = size,
    Categories = categories,
    DataSets = datasets
};
```

## 8. 100% Stacked Column Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/StackedColumn100Chart.jpg" />

```csharp
var chart = new StackedColumn100Chart
{
    Legend = new LegendModel
    {
        Margin = new PointF(0, 40),
        VerticalAlign = VerticalAlign.Bottom,
        HorizontalAlign = HorizontalAlign.Center
    },
    Padding = new Padding(80, 20, 20, 120),
    BarSetting = new BarSettingModel
    {
        Size = 70,
    },
    SubTitle = new SubTitleModel { Text = "AAAAAAA" },
    Size = size,
    Categories = new[] { "Product A", "Product B", "Product C" },
    DataSet = new[]
    {
        new DataSeries
        {
            Label = "LightBlue",
            Color = Color.LightBlue,
            Data = new[] { 25f, 3f, 3f },
        },
        new DataSeries
        {
            Label = "LightCoral",
            Color = Color.LightCoral,
            Data = new[] { 25f, 3f, 2f },
        }
        ,
        new DataSeries
        {
            Label = "LightGreen",
            Color = Color.LightGreen,
            Data = new[] { 50f, 3f, 5f },
        }
    }
};
```


## 9. Radar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/RadarChart.jpg" />

```csharp
var categories = new[] { "Eating", "Sleeping", "Doing Nothing", "Playing", "Relaxing", "Watching" };
var chart = new RadarChart
{
    //   MaxDataValue = 100,
    StepSize = 10,
    Size = size,
    Categories = categories,
    DataSets = new[]
    {
        new RadarChartSeries
        {
            Label = "My Life",
            Color = Color.LightCoral,
            Data = GenerateRandomArray(random, categories.Length, 1, 50),
        },
        new RadarChartSeries
        {
            Label = "My Wife Life",
            Color = Color.LightBlue,
            Data = GenerateRandomArray(random, categories.Length, 1, 100),
        }
    }
};
```
## 10. Single Range Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/SingleRangeBarChart.jpg" />

```csharp
const float MinValue = 10;
const float MaxValue = 15;
var values = new[] { 11, 12, 15 };
var rand = new Random();
var entries = new SingleRangeBarEntry[values.Length];

for (int i = 0; i < entries.Length; i++)
{
    entries[i] = new SingleRangeBarEntry
    {
        Value = values[i],
        Color = Color.FromArgb(rand.Next(0, 200), rand.Next(0, 200), rand.Next(0, 200)),
        Label = "Data " + i
    };
}

var chart = new SingleRangeBarChart
{
    MinValue = MinValue,
    MaxValue = MaxValue,
    Size = size,
    Entries = entries,
    LeftLabel = "Min \nvalue = 10",
    CenterLabel = "Center = ?",
    RightLabel = "Max \nvalue = 15",
    Font = new SlimFont("Arial", 12),
    TextColor = Color.Black
};
```
