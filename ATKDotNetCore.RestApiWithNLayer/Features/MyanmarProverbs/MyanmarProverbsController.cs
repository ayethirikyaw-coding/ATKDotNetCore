using Newtonsoft.Json;

namespace ATKDotNetCore.RestApiWithNLayer.Features.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private async Task<MyanmarProverbs> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("MyanmarProverbs.json");
            var model = JsonConvert.DeserializeObject<MyanmarProverbs>(jsonStr);
            return model!;
        }

        [HttpGet("titles")]
        public async Task<IActionResult> Titles()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        //[HttpGet("Proverbs/{titleId}")]
        //public async Task<IActionResult> GetProverbs(int titleId)
        //{
        //    var model = await GetDataAsync();
        //    return Ok(model.Tbl_MMProverbs.Where(x => x.TitleId == titleId));
        //}

        [HttpGet("Proverbs/{titleName}")]
        public async Task<IActionResult> GetProverbs(string titleName)
        {
            var model = await GetDataAsync();
            var titleLst = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName)!;
            return Ok(model.Tbl_MMProverbs.Where(x => x.TitleId == titleLst.TitleId));
        }

        [HttpGet("ProverbDescription/{proverbName}")]
        public async Task<IActionResult> GetProverbDescription(string proverbName)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbs.FirstOrDefault(x => x.ProverbName == proverbName));
        }
    }

    public class MyanmarProverbs
    {
        public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
        public Tbl_Mmproverbs[] Tbl_MMProverbs { get; set; }
    }

    public class Tbl_Mmproverbstitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }

    public class Tbl_Mmproverbs
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
    }
}
