using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [Column(TypeName ="varchar")]
        [MaxLength(250)]
        public string NameTag { set; get; }


        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Type { set; get; }

        public virtual IEnumerable<ProductTag> ProductTag { set; get; }
        public virtual IEnumerable<PostTag> PostTag { set; get; }
    }
}

