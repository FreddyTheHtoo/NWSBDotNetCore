using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWSBDotNetCore.ConsoleAppRefitExample
{

     public interface IBlogApi
    {
        [Get("/api/ui_blog")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/ui_blog/{id}")]
        Task<BlogModel> GetBlog(int id);

        [Post("/api/ui_blog")]
        Task<string> CreateBlog(BlogModel blog);

        [Put("/api/ui_blog/{id}")]
        Task<string> UpdateBlog(int id,BlogModel blog);

        [Delete("/api/ui_blog/{id}")]
        Task<string> DeleteBlog(int id);     

    }


}
public class BlogModel

{
   
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }

    public string? BlogAuthor { get; set; }

    public string? BlogContent { get; set; }

}
