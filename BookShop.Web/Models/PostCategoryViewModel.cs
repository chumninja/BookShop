using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.Models
{
    public class PostCategoryViewModel
    {
        public int ID { set; get; }


        public string NamePost { set; get; }


        public string Alias { set; get; }


        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }


        public string Images { set; get; }

        public bool? HomeFlag { set; get; }

        public DateTime? CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }

        public string MetaKeyWord { set; get; }
        public string MetaDescription { set; get; }
        public bool Status { set; get; }

        // ko nằm trong đây chi dùng để tham chiếu
        public virtual IEnumerable<PostViewModel> Post { set; get; }
    }
}