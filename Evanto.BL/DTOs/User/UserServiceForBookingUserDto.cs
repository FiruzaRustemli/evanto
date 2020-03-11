using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class UserServiceForBookingUserDto
    {

            public int Id { get; set; }


            public int UserId { get; set; }


            public int ServiceId { get; set; }


            public int UserEventId { get; set; }


            public bool Status { get; set; }


            public decimal? Budget { get; set; }


            public string Description { get; set; }


            public DateTime? CreatedDate { get; set; }

            public ServiceUserDto Service { get; set; }
            public UserEventUserDto UserEvent { get; set; }

    }
}
