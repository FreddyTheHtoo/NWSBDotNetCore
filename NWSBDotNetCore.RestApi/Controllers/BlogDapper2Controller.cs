using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Localization;
using NWSBDotNetCore.RestApi.Models;
using NWSBDotNetCore.Shared;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NWSBDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
      
        //private readonly IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        
        private BLogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where BlogId="+id;
            var item = _dapperService.QueryFirstOrDefault<BLogModel>(query, new BLogModel { BlogId = id });
            return item;
        } 

        [HttpGet]
        public IActionResult GetBlogs()
        {
            
            string query = "select * from Tbl_Blog";
            var lst = _dapperService.Query<BLogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {

            //string query = "select * from Tbl_Blog where blogid=@BlogId";
            //var item = _dapperService.Query<BLogModel>(query, new BLogModel { BlogId = id }).FirstOrDefault();
            ////FirstOrDefaul(); ka default value ko null anay nk htar pay poh
            //if(item == null)
            var item= FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BLogModel blog)
        {
           
            string query = @"insert into [dbo].[tbl_blog]
            ([BlogTitle],[BlogAuthor],[BlogContent]) values 
            (@BlogTitle,@BlogAuthor,@BlogContent)";

            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            
            return Ok(message);
        }



        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BLogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            blog.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
     SET        [BlogTitle]=@BlogTitle
            ,[BlogAuthor]=@BlogAuthor
            ,[BlogContent]=@BlogContent
    WHERE BlogId=@BlogId";

            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }


        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BLogModel blog)
        {
            blog.BlogId = id;
            string condition = string.Empty;
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                condition += " [BlogTitle]=@BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                condition += " [BlogAuthor]=@BlogAuthor, ";

            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                condition += " [BlogContent]=@BlogContent, ";
            }
            if(condition.Length == 0)
            {
                return NotFound("No data to update.");

            }

            condition = condition.Substring(0, condition.Length - 2);
            
            string query = $@"UPDATE [dbo].[Tbl_Blog] SET {condition} WHERE BlogId=@BlogId";

            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId=@BlogId";
            int result = _dapperService.Execute(query, new BLogModel { BlogId=id});
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            return Ok(message);
        }

    }
}
