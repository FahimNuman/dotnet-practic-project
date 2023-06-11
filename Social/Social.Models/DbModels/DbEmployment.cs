using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Models.DbModels
{
    public class DbEmployment:BaseClassInfo
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPresent { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public virtual DbUser? User { get; set; }
    }
}
