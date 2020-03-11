using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class ServicePeriodPriceUserDto
    {
        public int Id { get; set; }


        public int ServiceId { get; set; }


        public int PeriodId { get; set; }


        public decimal Price { get; set; }


        public DateTime? CreatedDate { get; set; }

        public ServiceUserDto Service { get; set; }
    }
}
