using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorOperation : Operation<UpdateVendorInput, UpdateVendorOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion
        public override void DoExecute()
        {
            UpdateVendorOutput output = new UpdateVendorOutput();

            Vendor vendor = this.Uow.GetRepository<Vendor>().GetById(this.Parameters.CurrentUserId);
            vendor.Address = this.Parameters.Address;

            vendor.User = Mapper.Map<UpdateVendorInput, User>(this.Parameters,vendor.User);
                        
            this.Uow.GetRepository<Vendor>().Update(vendor);
            this.Uow.SaveChanges();

            output.Vendor = Mapper.Map<Vendor, VendorDto>(vendor);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
