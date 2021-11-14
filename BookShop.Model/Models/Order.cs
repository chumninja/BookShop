using BookShop.Model.Abtract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BookShop.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public int? CustomerID { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string CustomerName { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string CustomerAddress { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string CustomerMail { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string CustomerPhone { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string CustomerMessage { set; get; }

        public DateTime? CreateDate { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string PaymentMethod { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string PaymentStatus { set; get; }
        public bool Status { set; get; }

        public virtual IEnumerable<OrderDetail> OderDetails { set; get; }

    }
}
