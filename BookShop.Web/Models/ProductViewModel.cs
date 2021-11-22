using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.Models
{
    public class ProductViewModel
    {
        public int ID { set; get; }
       
        public string NameProduct { set; get; }

       
        public string Alias { set; get; }


        public int CategoryID { set; get; }

        
        public string MoreImage { set; get; }

        public decimal? Promotion { set; get; }
        public decimal GiaNhap { set; get; }

        public decimal Price { set; get; }

        
        public string Content { set; get; }

        
        public string Description { set; get; }

        public bool? HomeFlag { set; get; }

        
        public string Images { set; get; }

        public bool? HotFlag { set; get; }

        public int? ViewCount { set; get; }

        public string Tags { set; get; }
        public virtual ProductCategoryViewModel ProductCategory { set; get; }
        public DateTime? CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        string UpdateBy { set; get; }

        public string MetaKeyWord { set; get; }
        public string MetaDescription { set; get; }
        public bool Status { set; get; }
    }
}