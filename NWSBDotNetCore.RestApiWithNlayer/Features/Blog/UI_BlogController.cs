

using Microsoft.AspNetCore.Mvc;

namespace NWSBDotNetCore.RestApiWithNlayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]

    public class UI_BlogController : ControllerBase
    {
        private readonly BusinessLogic_Blog _bl_blog;

        public UI_BlogController()
        {
            _bl_blog = new BusinessLogic_Blog();
        }

        [HttpGet]//does not support Body
        public IActionResult Read()
        {
            var lst = _bl_blog.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]

        public IActionResult Edit(int id)
        {
            var item = _bl_blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel Blog)
        {
            var result = _bl_blog.CreateBlog(Blog);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")] //edit entire whole column of table 
        public IActionResult Update(int id, BlogModel Blog)
        {
            var item = _bl_blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            var result = _bl_blog.UpdateBlog(id, Blog);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);

        }

        [HttpPatch("{id}")] //edit only one field in column of table
        public IActionResult Patch(int id, BlogModel Blog)
        {
            var item = _bl_blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            var result = _bl_blog.PatchBlog(id, Blog);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);

        }

        [HttpDelete("{id}")]//does not support Body
        public IActionResult Delete(int id)
        {
            var item = _bl_blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            var result = _bl_blog.DeleteBlog(id);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }
    }
}
