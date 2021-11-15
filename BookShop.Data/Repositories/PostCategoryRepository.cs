using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface IPostCategoryRepository { }
    public class PostCategoryRepository:RepositoryBase<PostCategory>,IPostCategoryRepository
    {
        public PostCategoryRepository(IDBFactory dbFactory):base(dbFactory) { }
    }
}
