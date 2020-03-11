using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.DTOs.Admin
{
    public class PaymentAdminDto
    {
        public int Id { get; set; }


        public int VendorId { get; set; }


        public int StatusId { get; set; }


        public decimal Amount { get; set; }


        public DateTime PaymentDate { get; set; }


        public int PaymentTypeId { get; set; }


        public string Description { get; set; }


        public DateTime? CreatedDate { get; set; }


        public PaymentStatusAdminDto PaymentStatus { get; set; }


        public PaymentTypeAdminDto PaymentType { get; set; }
    }
}
