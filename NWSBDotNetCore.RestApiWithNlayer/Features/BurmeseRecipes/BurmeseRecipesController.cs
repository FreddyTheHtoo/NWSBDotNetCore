using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NWSBDotNetCore.RestApiWithlayer.Features.BurmeseRecipes
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurmeseRecipesController : ControllerBase
    {
        private async Task<BMRecipes> GetDataAsyn()
        {
            string str = await System.IO.File.ReadAllTextAsync("BurmeseRecipes.json");
            var model = JsonConvert.DeserializeObject<BMRecipes>(str);
            return model;
        }

        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            var model = await GetDataAsyn();
            return Ok(model.Property1);
        }
    }
}

public class BMRecipes
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public string Guid { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string CookingInstructions { get; set; }
    public string UserType { get; set; }
}
