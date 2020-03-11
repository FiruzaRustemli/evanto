using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.VendorServicePacketOperation
{
    public class UpdateVendorServicePacketByAdminInput:OperationParameters
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string Description { get; set; }
        
    }

    public class UpdateVendorServicePacketByAdminOutput
    {
        public VendorServicePacketByAdminDto VendorServicePacketByAdminDto { get; set; }=new VendorServicePacketByAdminDto();
    }
}
