using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface IProductTagRepository { }
    public class ProductTagRepository:RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}
