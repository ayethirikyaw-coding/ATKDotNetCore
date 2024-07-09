namespace ATKDotNetCore.MvcChartApp.Models
{
    public class GroupedBarModel
    {
        public List<GroupBar> BarGroup { get; set; }

        public List<int> Categories { get; set; }
    }

    public class GroupBar
    {
        public List<int> data { get; set; } 
    }

}
