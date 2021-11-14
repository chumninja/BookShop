using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string NamePost { set; get; }

        [MaxLength(250)]
        [Column(TypeName = "varchar")]
        public string Alias { set; get; }

        [Column(TypeName = "nvarchar")]
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }

        [Column(TypeName = "varchar")]
        public string Images { set; get; }

        public bool? HomeFlag { set; get; }
        // ko nằm trong đây chi dùng để tham chiếu
        public virtual IEnumerable<Post> Post { set; get; }
    }
}
