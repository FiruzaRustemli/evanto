using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.FileOperations
{
    public class InsertBulkImagesByVendorInput : OperationParameters
    {
        public List<FileVendorDto> Images { get; set; }
        public int VendorId { get; set; }
        public int VendorServiceId { get; set; }
    }

    public class InsertBulkImagesByVendorOutput
    {
        public List<FileVendorDto> Images { get; set; } = new List<FileVendorDto>();
        public List<FileVendorDto> FailedImages { get; set; } = new List<FileVendorDto>();
    }
}
