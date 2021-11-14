using BookShop.Model.Abtract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BookShop.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        
        public int OderID { set; get; }
        [Key]
        public int ProductID { set; get; }

        public int Quantity { set; get; }

        [ForeignKey("OderID")]
        public virtual Order Order { set; get; }

        [ForeignKey("ProductID")]
        public virtual Product Products { set; get; }
    }
}
