using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, Unicode(false), MaxLength(25)]
        public string Name { get; set; }

        public DateTime AddedOn { get; set; } = DateTime.Now;

        [Required, Unicode(false), MaxLength(30)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
