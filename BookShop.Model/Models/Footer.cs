using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookShop.Model.Models
{
    [Table("Footers")]
    public class Footer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Content { set; get; }
    }
}
