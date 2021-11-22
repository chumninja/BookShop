using BookShop.Model.Abtract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BookShop.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string NameProduct { set; get; }

        [Column(TypeName = "varchar")]
        [MaxLength(250)]
        public string Alias { set; get; }

        
        public int CategoryID { set; get; }

        [Column(TypeName = "xml")]
        public string MoreImage { set; get; }

        public decimal? Promotion { set; get; }
        public decimal GiaNhap { set; get; }

        public decimal Price { set; get; }

        [Column(TypeName = "nvarchar")]
        public string Content { set; get; }

        [Column(TypeName = "nvarchar")]
        public string Description { set; get; }

        public bool? HomeFlag { set; get; }

        [Column(TypeName = "varchar")]
        public string Images { set; get; }

        public bool? HotFlag { set; get; }

        public int? ViewCount { set; get; }

        public string Tags { set; get; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { set; get; }

       
    }
}
