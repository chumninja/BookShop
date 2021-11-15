using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface IOrderDetailsReposioty : IRepository<OrderDetail> { }
    public class OrderDetailsRepository:RepositoryBase<OrderDetail>,IOrderDetailsReposioty
    {
        public OrderDetailsRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}
