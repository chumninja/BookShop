using BookShop.Model.Abtract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BookShop.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [Column(TypeName ="nvarchar")]
        [MaxLength(250)]
        public string NameCategory { set; get; }

        [Column(TypeName = "varchar")]
        [MaxLength(250)]
        public string Alias { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }

        [Column(TypeName = "varchar")]
        public string Images { set; get; }

        public bool? HomeFlag { set; get; }
        // ko nằm trong đây chi dùng để tham chiếu
        public virtual IEnumerable<Product> Products { set; get; }
    }
}
