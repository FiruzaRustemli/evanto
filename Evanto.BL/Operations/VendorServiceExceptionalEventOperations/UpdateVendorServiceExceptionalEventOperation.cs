using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.VendorServiceExceptionalEventOperations
{
    public class UpdateVendorServiceExceptionalEventOperation : Operation<UpdateVendorServiceExceptionalEventInput, UpdateVendorServiceExceptionalEventOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion

        public override void DoExecute()
        {
            UpdateVendorServiceExceptionalEventOutput output = new UpdateVendorServiceExceptionalEventOutput();
            VendorServiceExceptionalEvent vendorServiceExceptionalEvent = this.Uow.GetRepository<VendorServiceExceptionalEvent>().GetById(this.Parameters.Id);

            vendorServiceExceptionalEvent.VendorServiceId = this.Parameters.VendorServiceId;
            vendorServiceExceptionalEvent.EventId = this.Parameters.EventId;
            vendorServiceExceptionalEvent.Description = this.Parameters.Description;


            this.Uow.GetRepository<VendorServiceExceptionalEvent>().Update(vendorServiceExceptionalEvent);
            this.Uow.SaveChanges();

            output.VendorServiceExceptionalEvent = Mapper.Map<VendorServiceExceptionalEvent, VendorServiceExceptionalEventDto>(vendorServiceExceptionalEvent);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
