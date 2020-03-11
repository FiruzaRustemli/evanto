using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class EventServiceUserDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ServiceId { get; set; }
        public ServiceUserDto Service { get; set; }
    }
}
