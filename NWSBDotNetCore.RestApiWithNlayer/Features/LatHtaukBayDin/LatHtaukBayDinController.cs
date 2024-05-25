using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace NWSBDotNetCore.RestApiWithNlayer.Features.LatHtaukBayDin;

[Route("api/[controller]")]
[ApiController]
public class LatHtaukBayDinController : ControllerBase
{
    private async Task<LatHtaukBayDin> GetDataAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("data3.json");
        var model = JsonConvert.DeserializeObject<LatHtaukBayDin>(jsonStr);
        return model;
    }

    [HttpGet("question")]
    public async Task<IActionResult> Question()
    {
        var model = await GetDataAsync();
        return Ok(model.questions);
    }

    [HttpGet]
    public async Task<IActionResult> NumberList()
    {
        var model = await GetDataAsync();
        return Ok(model.numberList);
    }

    [HttpGet("{questionNo}/{no}")]
    public async Task<IActionResult> Answer(int questionNo, int no)
    {
        var model = await GetDataAsync();
        var lst = model.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == no);
        return Ok(lst);
    }

    


}

public class LatHtaukBayDin
{
public Question[] questions { get; set; }
public Answer[] answers { get; set; }
public string[] numberList { get; set; }
}

public class Question
{
public int questionNo { get; set; }
public string questionName { get; set; }
}

public class Answer
{
public int questionNo { get; set; }
public int answerNo { get; set; }
public string answerResult { get; set; }
}
