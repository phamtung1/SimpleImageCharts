# SimpleImageCharts
This is a simple charting library for rendering charts as images. 

# Install 

.NET Standard 2.0

# Available Charts
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
    IsDonut = true // the only difference
};

var bitmap = chart.CreateImage();
```

## 3. Horizontal Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/horzBar.jpg" />

```csharp
var chart = new HorzBarChart
{
    Width = 300,
    Height = 600,
    Categories = new[] { "A", "Product B", "Product C" },
    DataSets = new[]
    {
        new HorzBarSeries
        {
            Color = Color.Green,
            Data = new[] { -5f, 10f, 15f },
        },
        new HorzBarSeries
        {
            Color = Color.Red,
            Data = new[] { 1f, -2f, 3f },
        }
        ,
        new HorzBarSeries
        {
            Color = Color.Blue,
            Data = new[] { 5f, 20f, -13f },
        }
    }
};

var bitmap = chart.CreateImage();
```


## 4. Horizontal Bar Double Axis Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/HorzBarDoubleAxis.jpg" />

```csharp
var chart = new HorzBarDoubleAxisChart
{
    Width = 300,
    Height = 600,
    Categories = new[] { "Product A", "Product B", "Product C", "Product D", "Product E", "Product F" },
    FirstDataSet = new HorzBarDoubleAxisSeries 
    { 
        Color = Color.Green,
        Data = new[] { 5f, 10f, 5f, 1f, 12f, 7f },
    },
    SecondDataSet = new HorzBarDoubleAxisSeries
    {
        Color = Color.Red,
        Data = new[] { 15f, 10f, 15f, 8f, 2f, 14f },
    }
};

var bitmap = chart.CreateImage();
```

## 5. Vertical Bar Chart
<img src="https://raw.githubusercontent.com/phamtung1/SimpleImageCharts/master/screenshots/vertBar.jpg" />

```csharp
var categories = new[] { "A", "Product B", "Product C", "Product D", "Product E" };
var rand = new Random();
var datasets = new VertBarSeries[4];
for (int i = 0; i < datasets.Length; i++)
{
    var data = new float[categories.Length];
    for (int j = 0; j < categories.Length; j++)
    {
        data[j] = rand.Next(20) - 10;
    }

    var dataset = new VertBarSeries
    {
        Color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)),
        Data = data
    };
    datasets[i] = dataset;
}

var chart = new VertBarChart
{
    Width = 600,
    Height = 300,
    Categories = categories,
    DataSets = datasets
};

var bitmap = chart.CreateImage();
```
