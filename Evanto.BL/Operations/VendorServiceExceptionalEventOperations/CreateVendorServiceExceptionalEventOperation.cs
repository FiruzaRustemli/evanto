using Evanto.DAL.Context;

namespace Evanto.BL.Operations.VendorServiceExceptionalEventOperations
{
    public class CreateVendorServiceExceptionalEventOperation : Operation<CreateVendorServiceExceptionalEventInput, CreateVendorServiceExceptionalEventOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion

        public override void DoExecute()
        {
            CreateVendorServiceExceptionalEventOutput output = new CreateVendorServiceExceptionalEventOutput();
            VendorServiceExceptionalEvent vendorServiceExceptionalEvent
                = Mapper.Map<CreateVendorServiceExceptionalEventInput, VendorServiceExceptionalEvent >(this.Parameters);

            this.Uow.GetRepository<VendorServiceExceptionalEvent>().Add(vendorServiceExceptionalEvent);
            this.Uow.SaveChanges();

            output.IsCreated = true;
            Result.Output = output;
        }
    }
}
