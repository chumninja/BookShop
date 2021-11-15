using BookShop.Data.Infastructure;
using BookShop.Model.Models;

namespace BookShop.Data.Repositories
{
    public interface IMenuRepository
    {

    }
    public class MenuRepository:RepositoryBase<Menu>,IMenuRepository
    {
        public MenuRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}
