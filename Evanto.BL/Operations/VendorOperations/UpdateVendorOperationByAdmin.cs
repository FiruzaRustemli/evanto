using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorOperationByAdmin : Operation<UpdateVendorInputByAdmin, UpdateVendorOutputByAdmin>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion
        public override void DoExecute()
        {
            UpdateVendorOutputByAdmin output = new UpdateVendorOutputByAdmin();

            Vendor vendor = this.Uow.GetRepository<Vendor>().GetById(this.Parameters.UserId);
            vendor.Address = this.Parameters.Address;
           
            vendor.User = Mapper.Map(this.Parameters,vendor.User);
                        
            this.Uow.GetRepository<Vendor>().Update(vendor);
            this.Uow.SaveChanges();

            output.Vendor = Mapper.Map<Vendor, Evanto.BL.DTOs.Admin.VendorDto>(vendor);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
