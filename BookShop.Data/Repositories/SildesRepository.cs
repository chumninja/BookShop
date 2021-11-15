﻿using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface ISildesRepository { }
    public class SildesRepository:RepositoryBase<Sildes>, ISildesRepository
    {
        public SildesRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}