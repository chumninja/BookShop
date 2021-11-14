using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model.Models
{
    [Table("Sildes")]
    public class Sildes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [Column(TypeName ="nvarchar(500)")]
        [MaxLength(500)]
        public string Name { set; get; }

        [Column(TypeName = "nvarchar(Max)")]
        public string Description { set; get; }
        [Column(TypeName = "varchar(Max)")]
        public string Images { set; get; }

        [Column(TypeName = "varchar(Max)")]
        public string Url { set; get; }

        public int? DisplayOrder { set; get; }
        public bool Status { set; get; }

    }
}
