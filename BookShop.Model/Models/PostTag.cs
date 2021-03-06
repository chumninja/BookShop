using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        public int PostID { set; get; }

        [Key]
        public int TagID { set; get; }

        [ForeignKey("PostID")]
        public virtual Product product { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tags { set; get; }
    }
}
