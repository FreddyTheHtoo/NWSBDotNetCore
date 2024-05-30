using NWSBDotNetCore.Nlayer.DataAccess.Models;
using NWSBDotNetCore.Nlayer.DataAccess.Services;

namespace NWSBDotNetCore.Nlayer.BusinessLogic.Service
{
    public class BusinessLogic_Blog
    {
        private readonly DataAsset_Blog _daBlog;
        public BusinessLogic_Blog()
        {
            _daBlog = new DataAsset_Blog();
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = _daBlog.GetBlogs();
            return lst;
        }

        public BlogModel GetBlog(int id)
        {
            var item = _daBlog.GetBlog(id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            var model = _daBlog.CreateBlog(requestModel);
            return model;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var result = _daBlog.UpdateBlog(id, requestModel);
            return result;

        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            var result = _daBlog.PatchBlog(id, requestModel);
            return result;
        }
        public int DeleteBlog(int id)
        {
            var result = _daBlog.DeleteBlog(id);
            return result;

        }

        public async Task CreatBlog()
        {
            throw new NotImplementedException();
        }
    }
}
