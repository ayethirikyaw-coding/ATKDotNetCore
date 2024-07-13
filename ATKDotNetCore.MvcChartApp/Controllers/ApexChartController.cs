﻿using ATKDotNetCore.MvcChartApp.Models.ApexChart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATKDotNetCore.MvcChartApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            PieChartModel model = new PieChartModel();
            model.Series = new List<int> { 44, 55, 13, 43, 22 };
            model.Labels = new List<string>() { "Team A", "Team B", "Team C", "Team D", "Team E" };
            return View(model);
        }

        public IActionResult GroupedBar()
        {
            GroupedBarModel model = new GroupedBarModel();
            GroupBar firstBar = new GroupBar();
            firstBar.data = new List<int> { 44, 55, 41, 64, 22, 43, 21 };

            GroupBar secBar = new GroupBar();
            secBar.data = new List<int> { 53, 32, 33, 52, 13, 44, 32 };

            model.BarGroup = new List<GroupBar> { firstBar, secBar };
            model.Categories = new List<int> { 2001, 2002, 2003, 2004, 2005, 2006, 2007 };

            return View(model);
        }
    }
 
}
