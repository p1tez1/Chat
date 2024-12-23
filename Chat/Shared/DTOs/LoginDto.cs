using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Shared.DTOs
{
    public class LoginDto
    {
        [Required, MaxLength(25)]
        public string Name { get; set; }

        [Required, MaxLength(30)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
