using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Infastructure
{
    public interface IRepository<T> where T: class
    {
        //Dinh ngia cac phuong thuc co sang
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteMulti(Expression<Func<T, bool>> where);
        T GetSingByID(int id);
        T GetSingByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        IQueryable<T> GetAll(string[] inlcudes = null);
        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] inlcudes = null);
        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] inlcudes = null);
        int count(Expression<Func<T, bool>> where);
        bool CheckContains(Expression<Func<T, bool>> predicate);


    }
}
