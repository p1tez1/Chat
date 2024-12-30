using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Shared.DTOs
{
    public record struct UserDto(Guid Id, string Name);
}
