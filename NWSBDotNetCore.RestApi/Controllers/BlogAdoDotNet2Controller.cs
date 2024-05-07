using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using NWSBDotNetCore.RestApi.Models;
using NWSBDotNetCore.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using SqlConnection = System.Data.SqlClient.SqlConnection;
using SqlDataAdapter = System.Data.SqlClient.SqlDataAdapter;

namespace NWSBDotNetCore.RestApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase

    {
        //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {

            string query = " select * from Tbl_Blog";
            var lst = _adoDotNetService.Query<BLogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            //take a space to show database data
                string query = " select * from Tbl_Blog where BlogId = @BlogId";
            //AdoDotNetParameter[] parameters= new AdoDotNetParameter[1];
            //parameters[0]=new AdoDotNetParameter("@BlogId", id);
            var lst = _adoDotNetService.QueryFirstOrDefault<BLogModel>(query,new AdoDotNetParameter("@BlogId", id));

            if (lst is null)
            {
                return NotFound("No data found.");
            }
       
            return Ok(lst);

        }

        [HttpPost]
        public IActionResult CreateBlog(BLogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
               ([BlogTitle]
               ,[BlogAuthor]
               ,[BlogContent])
         VALUES
               (@BlogTitle
               ,@BlogAuthor
               ,@BlogContent)";
            var result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle",blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor",blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent",blog.BlogContent));
            string msg = result > 0 ? "Saving Successful" : "Saving Failed.";
            return Ok(msg);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BLogModel blog)
        {      
         string query = @"UPDATE [dbo].[Tbl_Blog]
         SET        [BlogTitle]=@BlogTitle
                ,[BlogAuthor]=@BlogAuthor
                ,[BlogContent]=@BlogContent
        WHERE BlogId="+ id;

            var result= _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            string msg = result > 0 ? "Updating Successful" : "Updating Failed.";
            return Ok(msg);

        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BLogModel blog)
        {

            string queryFind = " select * from Tbl_Blog where BlogId = @BlogId";
            var lst = _adoDotNetService.QueryFirstOrDefault<BLogModel>(queryFind, new AdoDotNetParameter("@BlogId", id));

            if (lst is null)
            {
                return NotFound("No matched ID found.");
            }

            blog.BlogId = id;
            string condition = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
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
            if (condition.Length == 0)
            {
                return NotFound("No data to update.");

            }

            condition = condition.Substring(0, condition.Length - 2);

            string query = $@"UPDATE [dbo].[Tbl_Blog] SET {condition} WHERE BlogId=@BlogId";
            var result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogId", blog.BlogId),
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            string msg = result > 0 ? "Updating Successful" : "Updating Failed.";
            return Ok(msg);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string queryFind = " select * from Tbl_Blog where BlogId = @BlogId";
            var lst = _adoDotNetService.QueryFirstOrDefault<BLogModel>(queryFind, new AdoDotNetParameter("@BlogId", id));

            if (lst is null)
            {
                return NotFound("No matched ID found.");
            }

              string query = "delete from [dbo].[tbl_blog] where BlogId="+id;
            var result = _adoDotNetService.Execute(query);
                string message = result > 0 ? "Deleting Successful." : "Deleting Failed";

            return Ok(message);
        }
    }
}
