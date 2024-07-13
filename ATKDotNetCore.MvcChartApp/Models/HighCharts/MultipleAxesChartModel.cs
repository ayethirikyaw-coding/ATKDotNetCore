namespace ATKDotNetCore.MvcChartApp.Models.HighCharts;

public class MultipleAxesChartModel
{
    public List<MultipleAxesChartAxes> Axes { get; set; }
}

public class MultipleAxesChartAxes
{
    public string Name { get; set; }

    public string Type { get; set; }

    public int YAxis { get; set; }

    public List<double> Data { get; set; }

    public MultipleAxesChartMarker? Marker { get; set; }

    public string? Dashstyle { get; set; }

    public MultipleAxesChartTooltip Tooltip { get; set; }
}

public class MultipleAxesChartMarker
{
    public bool Enabled { get; set; }
}

public class MultipleAxesChartTooltip
{
    public string ValueSuffix { get; set; }
}