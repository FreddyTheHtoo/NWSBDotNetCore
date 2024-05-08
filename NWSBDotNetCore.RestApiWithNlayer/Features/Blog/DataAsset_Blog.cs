﻿using Microsoft.AspNetCore.Http.HttpResults;
using NWSBDotNetCore.RestApiWithNlayer.Db;

namespace NWSBDotNetCore.RestApiWithNlayer.Features.Blog
{
    public class DataAsset_Blog
    {
        private readonly AppDbContext _context;
        public DataAsset_Blog()
        {
            _context = new AppDbContext();
        }
        
        public List<BlogModel> GetBlogs()
        {
            var lst= _context.Blogs.ToList();
            return lst;
        }

        public BlogModel GetBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
             _context.Blogs.Add(requestModel);
            var model = _context.SaveChanges();
            return model;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            var result = _context.SaveChanges();
            return result;

        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                item.BlogTitle = requestModel.BlogTitle;
            }

            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                item.BlogTitle = requestModel.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {
                item.BlogContent = requestModel.BlogContent;
            }
            
            var result = _context.SaveChanges();
            return result;
        }
       
        public  int DeleteBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            _context.Remove(item);
            var result = _context.SaveChanges();
            return result;

        }
           

    }
}