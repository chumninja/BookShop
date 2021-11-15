﻿using BookShop.Data.Infastructure;
using BookShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface ITagRepository { }
    public class TagRepository:RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDBFactory dbFactory) : base(dbFactory) { }
    }
}