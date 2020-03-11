using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Admin
{
    public class RoleAdminDto
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public bool Status { get; set; }


        public string Description { get; set; }


        public DateTime? CreatedDate { get; set; }
    }
}
