using Evanto.BL.DTOs.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class UpdateVendorServiceInput: OperationParameters
    {
        public int VendorServiceId { get; set; }
        public string Name { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        //public int DailyQuantity { get; set; }
        public string Description { get; set; }
        public string AddressText { get; set; }
        public string ContactInfo { get; set; }
        public string CoordinateX { get; set; }
        public string CoordinateY { get; set; }

    }

    public class UpdateVendorServiceOutput
    {
        public VendorServiceVendorDto VendorService { get; set; }
    }
}
