using Newtonsoft.Json;
using NWSBDotNetCore.Nlayer.BusinessLogic.Service;
using NWSBDotNetCore.Nlayer.DataAccess.Models;

Console.WriteLine("Hello, World!");

BusinessLogic_Blog businessLogic_Blog= new BusinessLogic_Blog();
//businessLogic_Blog.GetBlogs();
List<BlogModel> blogs = businessLogic_Blog.GetBlogs();
string str= JsonConvert.SerializeObject(blogs).ToString();
Console.WriteLine(str);
//foreach (var item in blogs) 
//{
//    Console.WriteLine(item);
//}
