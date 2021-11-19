using AutoMapper;
using BookShop.Model.Models;
using BookShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            //Moi 1 loai doi tuong can dung 1 dong mappper nay
            //doi tuong nao tham gia deu can cau hinh mapper
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();
        }
    }
}