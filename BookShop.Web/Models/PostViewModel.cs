
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.Models
{
    public class PostViewModel
    {
        public int ID;
        public string NamePost { set; get; }

      
        public string Alias { set; get; }


        public int CategoryPostID { set; get; }

        public string MoreImage { set; get; }

     
        public string Content { set; get; }

       
        public string Description { set; get; }

        public bool? HomeFlag { set; get; }

       
        public string Images { set; get; }

        public bool? HotFlag { set; get; }

        public int? ViewCount { set; get; }
        public DateTime? CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }

        public string MetaKeyWord { set; get; }
        public string MetaDescription { set; get; }
        public bool Status { set; get; }

        public virtual PostCategoryViewModel PostCategory { set; get; }

        public virtual IEnumerable<PostTagViewModel> PostTags { set; get; }
    }
}