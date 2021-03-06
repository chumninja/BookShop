
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookShop.Model.Models
{
    [Table("MenuGroup")]
    public class MenuGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string Name { set; get; }
        public virtual IEnumerable<Menu> Menus { set; get; }
    }
}
