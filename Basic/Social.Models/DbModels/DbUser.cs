using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Models.DbModels
{
    public class DbUser
    {
        public int Id { get; set; }
        [Required]
        [StringLength(90)]
        [MinLength(3, ErrorMessage = "Name should be more than 3 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(90)]
        [MinLength(8, ErrorMessage = "Email should be more than 8 characters")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(150)]
        [MinLength(3, ErrorMessage = "Password should be more than 8 characters")]
        public string Password { get; set; } = string.Empty;
        [ForeignKey(nameof(RoleId))]
        public int RoleId { get; set; }
        public virtual DbRole? Role { get; set; }
    }
}
