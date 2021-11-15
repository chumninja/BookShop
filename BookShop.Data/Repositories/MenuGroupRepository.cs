using BookShop.Data.Infastructure;
using BookShop.Model.Models;


namespace BookShop.Data.Repositories
{
    public interface IMenuGroupRepository { }
    public class MenuGroupRepository:RepositoryBase<MenuGroup>,IMenuGroupRepository
    {
        public MenuGroupRepository(IDBFactory dbFactory): base(dbFactory) { }
    }
}
