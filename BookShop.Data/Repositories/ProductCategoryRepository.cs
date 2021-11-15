using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
        //phuong thuc khong nam trong tap phuong thuc trien khai RepositoryBase thi chung ta can dinh nghia
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>,IProductCategoryRepository
    {
        public ProductCategoryRepository(IDBFactory dbFactory) :base(dbFactory)
        {
            //tu dong inject vao

        }
        //phuong thuc moi ko lien quan trong file chung thi chung ta can viet rieng.
        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
