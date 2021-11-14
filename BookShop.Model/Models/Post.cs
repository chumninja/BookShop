using BookShop.Model.Abtract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookShop.Model.Models
{
    [Table("Posts")]
    public class Post : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(250)]
        [Column(TypeName ="nvarchar")]
        public string NamePost { set; get; }

        [MaxLength(250)]
        public string Alias { set; get; }


        public int CategoryPostID { set; get; }

        public XElement MoreImage { set; get; }

        [Column(TypeName = "nvarchar")]
        public string Content { set; get; }

        [Column(TypeName = "nvarchar")]
        public string Description { set; get; }

        public bool? HomeFlag { set; get; }

        [Column(TypeName = "varchar")]
        public string Images { set; get; }

        public bool? HotFlag { set; get; }

        public int? ViewCount { set; get; }

        [ForeignKey("CategoryPostID")]
        public virtual PostCategory PostCategory { set; get; }

        public virtual IEnumerable<PostTag> PostTag { set; get; }

    }
}
