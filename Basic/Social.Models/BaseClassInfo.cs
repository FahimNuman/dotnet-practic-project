using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Models
{
    public class BaseClassInfo
    {
        public int CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
