﻿using BookShop.Data.Infastructure;
using BookShop.Model.Models;

namespace BookShop.Data.Repositories
{
    public interface IProductRepository
    {

    }
    public class ProductRepository :RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(IDBFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}