using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorContactInformationsOperation
        : Operation<UpdateVendorContactInformationsInput, UpdateVendorContactInformationsOutput>
    {
        public override void DoExecute()
        {
            UpdateVendorContactInformationsOutput output = new UpdateVendorContactInformationsOutput();

            Vendor vendor = this.Uow.GetRepository<Vendor>().GetAll(u => u.UserId == this.Parameters.CurrentUserId, "User").ToList().First();
            vendor.Address = this.Parameters.Address;
            vendor.User.Username = this.Parameters.Username;
            vendor.User.Phone = this.Parameters.Phone;
            this.Uow.GetRepository<Vendor>().Update(vendor);
            this.Uow.SaveChanges();
            
            output.ContactInformation = new ContactInformationVendorDto();
            output.ContactInformation.Address = vendor.Address;
            output.ContactInformation.UserId = vendor.UserId;
            output.ContactInformation.Username = vendor.User.Username;
            output.ContactInformation.Phone = vendor.User.Phone;
            Result.Output = output;
            Result.Output.IsUpdated = true;
        }
    }
}
