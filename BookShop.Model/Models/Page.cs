using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BookShop.Model.Models
{
    [Table("Pages")]
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [Column(TypeName ="nvarchar")]
        [MaxLength(250)]
        public string NamePage { set; get; }

        [Column(TypeName = "nvarchar")]
        public string Content { set; get; }

        [Column(TypeName = "varchar")]
        [MaxLength(250)]
        public string Alias { set; get; }
    }
}
