using BookShop.Data.Infastructure;
using BookShop.Model.Models;


namespace BookShop.Data.Repositories
{
    public interface IOrderRepository { }
    public class OrderReposiory:RepositoryBase<Order>,IOrderRepository
    {
        public OrderReposiory(IDBFactory dbFactory) : base(dbFactory) { }
    }
}
