using System;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Admin;
using Evanto.Resources.Operations.Vendor.Update;

namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorInputByAdmin : OperationParameters
    {
        public int UserId { get; set; }

        public string Address { get; set; }


        public string Description { get; set; }


        public DateTime? CreatedDate { get; set; }

        public int RoleId { get; set; }


        public int TypeId { get; set; }


        public int StatusId { get; set; }


        //public int? MaritalStatus { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public DateTime? Birthday { get; set; }


        //public DateTime RegistrationDate { get; set; }


        public string Phone { get; set; }


        public string Username { get; set; }


        //public byte[] Salt { get; set; }


        //public byte[] Password { get; set; }


        //public int LoginCount { get; set; }


        //public DateTime LastLoginDate { get; set; }


        //public int? FailedLoginCount { get; set; }
    }

    public class UpdateVendorOutputByAdmin
    {
        public VendorDto Vendor { get; set; }
        public bool IsUpdated { get; set; } = false;
    }
}
