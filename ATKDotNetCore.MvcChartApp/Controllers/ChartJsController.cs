using ATKDotNetCore.MvcChartApp.Models.ChartJs;
using Microsoft.AspNetCore.Mvc;

namespace ATKDotNetCore.MvcChartApp.Controllers;

public class ChartJsController : Controller
{
    public IActionResult BarChart()
    {
        return View();
    }

    public IActionResult InterpolationLineChart()
    {
        return View();
    }

    private List<double> genereateRandomNumber(int count)
    {
        List<double> num = new List<double>();
        for (int i = 0; i < count; i++)
        {
            Random rnd = new Random();
            num.Add(rnd.Next(0, 100)); 
        }
        return num;
    }

    public IActionResult PolarAreaChart()
    {
        PolarAreaChartModel model = new PolarAreaChartModel();
        model.Labels = new List<string>() { "Red", "Orange", "Yellow", "Green", "Blue" };
        model.Dataset = new PolarAreaChartDataset()
        {
            Label = "Dataset 1",
            Data = genereateRandomNumber(5),
            BackgroundColor = new List<string>()
            {
                "rgba(255, 99, 132, 0.5)",
                "rgba(255, 159, 64, 0.5)",
                "rgba(255, 205, 86, 0.5)",
                "rgba(75, 192, 192, 0.5)",
                "rgba(54, 162, 235, 0.5)"
            }
        };
        return View(model);
    }
}
