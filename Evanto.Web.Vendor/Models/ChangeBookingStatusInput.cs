using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models
{
    public class ChangeBookingStatusInput
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }
}
