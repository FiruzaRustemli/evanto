using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Admin
{
    public class AdminVendorDto : IDtoBase
    {

        public int UserId { get; set; }


        public string Address { get; set; }


        public double? Rating { get; set; }


        public string Description { get; set; }


        public DateTime? CreatedDate { get; set; }


        public UserAdminDto User { get; set; }
    }
}
