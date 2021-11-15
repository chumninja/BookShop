using BookShop.Data.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Model.Models;

namespace BookShop.Data.Repositories
{
    public interface IVisitorSaticesRepository: IRepository<VisitorStatics> { }
    public class VisitorSaticesRepository:RepositoryBase<VisitorStatics>,IVisitorSaticesRepository
    {
        public VisitorSaticesRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}
