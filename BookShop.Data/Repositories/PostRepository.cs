using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface IPostRepository { }
    public class PostRepository:RepositoryBase<Post>,IPostRepository
    {
        public PostRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}
