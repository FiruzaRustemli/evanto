using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorBasicInformationOperation : Operation<UpdateVendorBasicInformationInput, UpdateVendorBasicInformationOutput>
    {
        public override void DoExecute()
        {
            UpdateVendorBasicInformationOutput output = new UpdateVendorBasicInformationOutput();
            output.VendorBasicInformation = new VendorBasicInformationDto();
            Vendor vendor = this.Uow.GetRepository<Vendor>().GetAll(u => u.UserId == this.Parameters.CurrentUserId, "User").ToList().First();
            
            vendor.User.Birthday = this.Parameters.BirthDate;
            vendor.User.FirstName = this.Parameters.FirstName;
            vendor.User.LastName = this.Parameters.LastName;
            vendor.User.MaritalStatus = this.Parameters.MaritalStatus;
            vendor.Name = this.Parameters.CompanyName;

            Uow.GetRepository<Vendor>().Update(vendor);
            Uow.SaveChanges();
            output.VendorBasicInformation.BirthDate = vendor.User.Birthday;
            output.VendorBasicInformation.FirstName = vendor.User.FirstName;
            output.VendorBasicInformation.LastName = vendor.User.LastName;
            output.VendorBasicInformation.MaritalStatus = vendor.User.MaritalStatus;
            output.VendorBasicInformation.CompanyName = vendor.Name;
            Result.Output = output;
            Result.Output.IsUpdated = true;
        }
    }
}
