using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Vendor
{
    public class NotificationsVendorDto<TDto>
    {
        public int CountUnread { get; set; }
        public IReadOnlyCollection<TDto> Data { get; set; }
    }
}
