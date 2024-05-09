using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using Newtonsoft.Json; 

namespace NWSBDotNetCore.RestApiWithNlayer.Features.Dream
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamController : ControllerBase
    {
        private async Task<DreamDto> GetDataAsyn()
        {
            string str = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<DreamDto>(str);
            return model;
        }

        [HttpGet("{BlogHeader}")]
        public async Task<IActionResult> Header()
        {
            var model= await GetDataAsyn();
            return Ok(model.BlogHeader);
        }

        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            var model = await GetDataAsyn();
            return Ok(model.BlogDetail);
        }
    }


    public class DreamDto
    {
        public Blogheader[] BlogHeader { get; set; }
        public Blogdetail[] BlogDetail { get; set; }
    }

    public class Blogheader
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
    }

    public class Blogdetail
    {
        public int BlogDetailId { get; set; }
        public int BlogId { get; set; }
        public string BlogContent { get; set; }
    }


}


