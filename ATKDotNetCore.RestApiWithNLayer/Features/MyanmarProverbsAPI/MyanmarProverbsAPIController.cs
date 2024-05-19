using Newtonsoft.Json;

namespace ATKDotNetCore.RestApiWithNLayer.Features.MyanmarProverbsAPI;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbsAPIController : ControllerBase
{

    private async Task<Tbl_Mmproverbs> GetDataFromApi()
    {
        //HttpClient httpClient = new HttpClient();
        //var response = await httpClient.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
        //if (!response.IsSuccessStatusCode) return null;

        //string jsonStr = await response.Content.ReadAsStringAsync();
        //var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
        //return model!;   

        var jsonStr = await System.IO.File.ReadAllTextAsync("MyanmarProverbs.json");
        var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
        return model!;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var model = await GetDataFromApi();
        return Ok(model.Tbl_MMProverbsTitle);
    }

    [HttpGet("{titleName}")]
    public async Task<IActionResult> Get(string titleName)
    {
        var model = await GetDataFromApi();
        //var titleId = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName).TitleId;//may be null
        //return Ok(model.Tbl_MMProverbsTitle.Where(x => x.TitleId == titleId));
        var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
        if (item is null) return NotFound();

        var titleId = item.TitleId;
        var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);

        List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
        {
            TitleId = x.TitleId,
            ProverbId = x.ProverbId,
            ProverbName = x.ProverbName
        }).ToList();

        return Ok(lst);
    }

    [HttpGet("{titleId}/{proverbId}")]
    public async Task<IActionResult> Get(int titleId, int proverbId)
    {
        var model = await GetDataFromApi();
        var item = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);
        return Ok(item);
    }
}


public class Tbl_Mmproverbs
{
    public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
    public Tbl_MmproverbsDetails[] Tbl_MMProverbs { get; set; }
}

public class Tbl_Mmproverbstitle
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
}

public class Tbl_MmproverbsDetails
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
    public string ProverbDesp { get; set; }
}

public class Tbl_MmproverbsHead
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
}

