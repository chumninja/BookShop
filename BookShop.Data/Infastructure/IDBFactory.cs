using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Infastructure
{
    public interface IDBFactory : IDisposable
    {
        BookShopDBConText Init();
    }
}
