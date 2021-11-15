using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Infastructure
{
    public class DBFactory : Disposable, IDBFactory//ke thua tu class va 1 interface dc
    {
        BookShopDBConText dbContext;
        public BookShopDBConText Init()
        {
            return dbContext ?? (dbContext = new BookShopDBConText());
            //kiem tra neu no null thi khoi tao 1 dbcontext moi
        }
        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
