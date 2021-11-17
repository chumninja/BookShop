using BookShop.Model.Models;
using BookShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.Infastucture.Extension
{
    public static class EntityExtension
    {
        //trong class static bắt buộc để phương thức là static
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVM)
        {
            //Dung trong truong hop update truyen thu PostCategoryView về viết z sau chi cần gọi ra thôi
            postCategory.ID = postCategoryVM.ID;
            postCategory.NamePost = postCategoryVM.NamePost;
            postCategory.Alias = postCategoryVM.Alias;
            postCategory.Description = postCategoryVM.Description;
            postCategory.ParentID = postCategoryVM.ParentID;
            postCategory.DisplayOrder = postCategoryVM.DisplayOrder;
            postCategory.Images = postCategoryVM.Images;
            postCategory.HomeFlag = postCategoryVM.HomeFlag;
            postCategory.CreateDate = postCategoryVM.CreateDate;
            postCategory.CreateBy = postCategoryVM.CreateBy;
            postCategory.UpdateDate = postCategoryVM.UpdateDate;
            postCategory.MetaKeyWord = postCategoryVM.MetaKeyWord;
            postCategory.MetaDescription = postCategoryVM.MetaDescription;
            postCategory.Status = postCategoryVM.Status;

        }

        public static void UpdatePost(this Post post, PostViewModel postVM)
        {
            //Dung trong truong hop update truyen thu PostCategoryView về viết z sau chi cần gọi ra thôi
            post.ID = postVM.ID;
            post.NamePost = postVM.NamePost;
            post.Alias = postVM.Alias;
            post.Description = postVM.Description;
            post.Content = postVM.Content;
            post.CategoryPostID = postVM.CategoryPostID;
            post.MoreImage = postVM.MoreImage;
            post.Images = postVM.Images;
            post.HomeFlag = postVM.HomeFlag;
            post.CreateDate = postVM.CreateDate;
            post.CreateBy = postVM.CreateBy;
            post.UpdateDate = postVM.UpdateDate;
            post.MetaKeyWord = postVM.MetaKeyWord;
            post.MetaDescription = postVM.MetaDescription;
            post.Status = postVM.Status;

        }

        
    }
}