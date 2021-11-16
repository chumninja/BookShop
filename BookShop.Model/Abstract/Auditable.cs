using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model.Abtract
{
    public abstract class Auditable : IAuditable
    {

        [MaxLength(256)]
        public string MetaDescription
        {
            get; set;
        }
        [MaxLength(256)]
        public string MetaKeyWord
        {
            get; set;
        }
        [MaxLength(256)]
        public string CreateBy
        {
            get; set;
        }

        public DateTime? CreateDate
        {
            get; set;
        }
        

        [MaxLength(256)]
        public string UpdateBy
        {
            get; set;
        }

        public DateTime? UpdateDate
        {
            get; set;
        }

        public bool Status
        {
            get;set;
        }
    }
}
