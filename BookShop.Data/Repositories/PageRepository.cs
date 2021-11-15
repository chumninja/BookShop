using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface IPageReposiory { }
    public class PageRepository:RepositoryBase<Page>,IPageReposiory
    {
        public PageRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}
