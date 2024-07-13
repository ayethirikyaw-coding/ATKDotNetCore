using ATKDotNetCore.MvcChartApp.Models.HighCharts;
using Microsoft.AspNetCore.Mvc;

namespace ATKDotNetCore.MvcChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }

        public IActionResult MultipleAxesChart()
        {
            MultipleAxesChartModel model = new MultipleAxesChartModel()
            {
                Axes = new List<MultipleAxesChartAxes>()
                {
                    new MultipleAxesChartAxes()
                    {
                        Name = "Rainfall",
                        Type = "column",
                        YAxis = 1,
                        Data = new List<double>()
                        {
                            49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5,
                            216.4, 194.1,95.6, 54.4
                        },
                        Tooltip = new MultipleAxesChartTooltip()
                         {
                            ValueSuffix = "mm"
                         }
                    },
                    new MultipleAxesChartAxes()
                    {
                        Name = "Sea-Level Pressure",
                        Type = "spline",
                        YAxis = 2,
                        Data = new List<double>()
                        {
                            1016, 1016, 1015.9, 1015.5, 1012.3, 1009.5, 1009.6,
                            1010.2, 1013.1,1016.9, 1018.2, 1016.7
                        },
                        Marker = new MultipleAxesChartMarker()
                        {
                            Enabled = false
                        },
                        Dashstyle = "shortdot",
                        Tooltip = new MultipleAxesChartTooltip()
                         {
                            ValueSuffix = "mb"
                         }
                    },
                    new MultipleAxesChartAxes()
                    {
                        Name = "Temperature",
                        Type = "spline",
                        Data = new List<double>()
                        {
                            7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3,
                            18.3, 13.9, 9.6
                        },
                        Tooltip = new MultipleAxesChartTooltip()
                        {
                            ValueSuffix = "°C"
                        }
                    }
                }
            };
            return View(model);
        }

        public IActionResult ThreeDPieChart()
        {
            ThreeDPieChartModel model = new ThreeDPieChartModel();
            List<ThreeDPieChartData> data = new List<ThreeDPieChartData>()
            {
                new ThreeDPieChartData()
                {
                    Name = "Samsung",
                    Y = 23
                },
                new ThreeDPieChartData()
                {
                    Name = "Apple",
                    Y = 18
                },
                new ThreeDSelectedPie()     //selecedPie
                {
                    Name = "Xiaomi",
                    Y = 12,
                    Selected = true,
                    Sliced = true
                },
                new ThreeDPieChartData()
                {
                    Name = "Oppo",
                    Y = 9
                },
                new ThreeDPieChartData()
                {
                    Name = "Vivo",
                    Y = 8
                },
                new ThreeDPieChartData()
                {
                    Name = "Others",
                    Y = 30
                }
            };
            model.Datas = data;
            return View(model);
        }
    }
}
