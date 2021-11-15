using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface IPostTagRepository { }
    public class PostTagRepository:RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}
