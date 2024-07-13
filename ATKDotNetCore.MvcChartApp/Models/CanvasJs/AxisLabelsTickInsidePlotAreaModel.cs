namespace ATKDotNetCore.MvcChartApp.Models.CanvasJs;

public class AxisLabelsTickInsidePlotAreaModel
{
    public List<AxisLabelsTickInsidePlotAreaDataPoints> DataPoints { get; set; }
}

public class AxisLabelsTickInsidePlotAreaDataPoints
{
    public string Label { get; set; }

    public double Y { get; set; }
}
