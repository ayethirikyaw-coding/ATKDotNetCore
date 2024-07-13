namespace ATKDotNetCore.MvcChartApp.Models.CanvasJs;

public class WaterFallChartModel
{
    public List<WaterFallData> data { get; set; }
}

public class WaterFallData
{
    public string Label { get; set; }

    public double Y { get; set; }

    public bool IsIntermediateSum { get; set; }

    public bool IsCumulativeSum { get; set; }
}

// [
// 	{ label: "Sales", y: 1273 },
// 	{ label: "Service", y: 623 },
// 	{ label: "Total Revenue", isIntermediateSum: true },
// 	{ label: "Research", y: -150 },
// 	{ label: "Marketing", y: -226 },
// 	{ label: "Salaries", y: -632 },
// 	{ label: "Operating Income", isCumulativeSum: true },
// 	{ label: "Taxes", y: -264 },
// 	{ label: "Net Income", isCumulativeSum: true }
// ]
