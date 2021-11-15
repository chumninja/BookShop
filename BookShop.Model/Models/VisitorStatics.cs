using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model.Models
{
    [Table("VisitorStatices")]
    public class VisitorStatics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public DateTime? VisitDate { set; get; }

        [Column(TypeName ="varchar")]
        public string IPAdress { set; get; }
    }
}
