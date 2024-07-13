namespace ATKDotNetCore.MvcChartApp.Models.HighCharts;

public class ThreeDPieChartModel
{
    public List<ThreeDPieChartData> Datas { get; set; }
}

public class ThreeDPieChartData
{
    public string Name { get; set; }
    public int Y { get; set; }
}

public class ThreeDSelectedPie : ThreeDPieChartData
{
    public bool Sliced { get; set; }
    public bool Selected { get; set; }
}
