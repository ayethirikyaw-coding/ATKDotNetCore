using ATKDotNetCore.MvcChartApp.Models.CanvasJs;
using Microsoft.AspNetCore.Mvc;

namespace ATKDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult LineChart()
        {
            return View();
        }

        public IActionResult AxisLabelsTickInsidePlotArea()
        {
            AxisLabelsTickInsidePlotAreaModel model = new AxisLabelsTickInsidePlotAreaModel();
            List<AxisLabelsTickInsidePlotAreaDataPoints> dataPoints = new List<AxisLabelsTickInsidePlotAreaDataPoints>()
            {
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                    Y = 4.91,
                    Label = "Learning Colors"
                },
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                    Y = 4.96,
                    Label = "Uptown Funk"
                },
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                    Y = 5.36,
                    Label = "Wheels on the Bus"
                },
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                   Y = 5.36,
                   Label = "Phonics Song with Two Words"
                },
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                    Y = 5.94,
                    Label = "See You Again"
                },
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                    Y = 6.02,
                    Label = "Shape of You"
                },
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                    Y = 6.26,
                    Label = "Bath Song"
                },
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                    Y = 6.73,
                    Label = "Johny Johny Yes Papa"
                },
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                    Y = 8.20,
                    Label = "Despacito"
                },
                new AxisLabelsTickInsidePlotAreaDataPoints
                {
                    Y = 13.01,
                    Label = "Baby Shark Dance"
                },
            };
            model.DataPoints = dataPoints;
            return View(model);
        }

        public IActionResult WaterFallChart()
        {
            WaterFallChartModel model = new WaterFallChartModel();
            model.data = new List<WaterFallData>()
            {
                new WaterFallData()
                {
                    Label = "Sales",
                    Y = 1273
                },
                new WaterFallData()
                {
                    Label = "Service",
                    Y = 623
                },
                new WaterFallData()
                {
                    Label = "Total Revenue",
                    IsIntermediateSum = true
                },
                new WaterFallData()
                {
                    Label = "Research",
                    Y = -150
                },
                new WaterFallData()
                {
                    Label = "Marketing",
                    Y = -226
                },
                new WaterFallData()
                {
                    Label = "Salaries",
                    Y = -632
                },
                new WaterFallData()
                {
                    Label = "Operating Income",
                    IsCumulativeSum = true
                },
                new WaterFallData()
                {
                    Label = "Taxes",
                    Y = -264
                },
                new WaterFallData()
                {
                    Label = "Net Income",
                    IsCumulativeSum = true
                }
            };
            return View(model);
        }
    }
}
