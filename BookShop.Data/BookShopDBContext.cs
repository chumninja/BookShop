using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BookShop.Data
{
    public class BookShopDBContext : DBContext
    {
        public BookShopDBContext() : base("BookShopConnection")//key connection been app config
        {
            this.Configuration.LazyLoadingEnabled = false;// khi ma ta include bang cha thi no se ko tu include ra bang con
        }
        public DBSet<Menu>
    }
}
