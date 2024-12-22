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
    [Table("Message")]
    public class Massage
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FromId { get; set; }    
        public Guid ToId { get; set; }

        [Required, MaxLength(500)]
        public string Content { get; set; }
        public DateTime SentOn { get; set; }
        public virtual User FromUser { get; set; }
        public virtual User ToUser {  get; set; } 
    }
}
