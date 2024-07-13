namespace ATKDotNetCore.MvcChartApp.Models.ChartJs;

public class PolarAreaChartModel
{
    public List<string> Labels { get; set; }

    public PolarAreaChartDataset Dataset { get; set; }
}

public class PolarAreaChartDataset
{
    public string Label { get; set; }

    public List<double> Data { get; set; }

    public List<string> BackgroundColor { get; set; }
}
