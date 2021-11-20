using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { set; get; }
       
        [Required]
        public string NameCategory { set; get; }

        [Required]
        public string Alias { set; get; }

      
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }

      
        public string Images { set; get; }

        public bool? HomeFlag { set; get; }
        // ko nằm trong đây chi dùng để tham chiếu
        public virtual IEnumerable<ProductViewModel> Products { set; get; }
        public DateTime? CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        string UpdateBy { set; get; }

        public string MetaKeyWord { set; get; }
        public string MetaDescription { set; get; }
        public bool Status { set; get; }
    }
}