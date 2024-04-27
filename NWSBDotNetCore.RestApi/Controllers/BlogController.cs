using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NWSBDotNetCore.ConsoleApp.Connections;
using NWSBDotNetCore.RestApi.Models;

namespace NWSBDotNetCore.RestApi.Controllers
{
    // domain name exp: (https://localhost:3000)
    [Route("api/[controller]")] //endpoint
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BlogController()
        {
            _context = new AppDbContext();

        }

        [HttpGet]//does not support Body
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]

        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x=> x.BlogId==id);
            if(item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BLogModel Blog)
        {
           _context.Blogs.Add(Blog);
            var result = _context.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Failed"; 
            return Ok(message);
        }

        [HttpPut("{id}")] //edit entire whole column of table 
        public IActionResult Update(int id,BLogModel Blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            
            item.BlogTitle = Blog.BlogTitle;
            item.BlogAuthor =  Blog.BlogAuthor;
            item.BlogContent = Blog.BlogContent;

           
            var result = _context.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
            
        }

        [HttpPatch("{id}")] //edit only one field in column of table
        public IActionResult Patch(int id, BLogModel Blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            if (!string.IsNullOrEmpty(Blog.BlogTitle))
            {
                item.BlogTitle = Blog.BlogTitle;
            }
            
            if (!string.IsNullOrEmpty(Blog.BlogAuthor))
            {
                item.BlogTitle = Blog.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(Blog.BlogContent))
            {
                item.BlogContent = Blog.BlogContent;
            }


            var result = _context.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);

        }

        [HttpDelete("{id}")]//does not support Body
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            _context.Blogs.Remove(item);
            var result =_context.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }
    }
}
