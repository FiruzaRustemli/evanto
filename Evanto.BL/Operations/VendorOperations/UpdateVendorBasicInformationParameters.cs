using System;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorBasicInformationInput : OperationParameters
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? MaritalStatus { get; set; }
        public string CompanyName { get; set; }
    }
    public class UpdateVendorBasicInformationOutput
    {
        public VendorBasicInformationDto VendorBasicInformation { get; set; }
        public bool IsUpdated { get; set; }
    }
}
