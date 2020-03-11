using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Core
{
    public class UserValidationDto : IDtoBase
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int RoleId { get; set; }

        public RoleDto Role { get; set; }
    }
}
