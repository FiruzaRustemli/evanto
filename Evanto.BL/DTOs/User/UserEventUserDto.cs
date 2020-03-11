using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class UserEventUserDto
    {
        public int Id { get; set; }


        public int UserId { get; set; }
        public string Name { get; set; }


        public bool Status { get; set; }


        public decimal? Budget { get; set; }


        public DateTime EventDate { get; set; }


        public string Description { get; set; }


        public DateTime? CreatedDate { get; set; }


        public virtual EventTypeUserDto EventType { get; set; }
    }
}
