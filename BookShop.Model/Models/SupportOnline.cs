using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [Column(TypeName ="nvarchar")]
        [MaxLength(250)]
        public string Name { set; get; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Department { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Skype { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Facebook { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Mobile { set; get; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Email { set; get; }

        public bool Status { set; get; }

    }
}
