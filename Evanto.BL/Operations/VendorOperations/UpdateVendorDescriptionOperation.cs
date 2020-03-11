using Evanto.DAL.Context;

namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorDescriptionOperation : Operation<UpdateVendorDescriptionInput, UpdateVendorDescriptionOutput>
    {
        public override void DoExecute()
        {
            UpdateVendorDescriptionOutput output = new UpdateVendorDescriptionOutput();
            var vendor = this.Uow.GetRepository<Vendor>().GetById(this.Parameters.CurrentUserId);
            vendor.Description = this.Parameters.Description;

            this.Uow.GetRepository<Vendor>().Update(vendor);
            this.Uow.SaveChanges();
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
