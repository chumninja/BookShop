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
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string ID { set; get; }

        [Required]
        [Column(TypeName ="varchar")]
        [MaxLength(250)]
        public string NameTag { set; get; }


        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Type { set; get; }

    }
}

