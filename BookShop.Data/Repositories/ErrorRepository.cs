using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface IErrorRepository:IRepository<Error> { }
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository { 

        public ErrorRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}
