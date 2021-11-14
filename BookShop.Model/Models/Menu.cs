using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Model.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string NameMenu { set; get; }

        [Column(TypeName = "varchar")]
        public string Link { set; get; }
        public int? DisplayOrder { set; get; }
        public string Target { set; get; }

        public int GroupID { set; get; }
        [ForeignKey("GroupID")]
        public virtual MenuGroup MenuGroup { set; get; }
        public bool Status { set; get; }

    }
}
