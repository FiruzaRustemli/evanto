using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetVendorServiceOperation : Operation<GetVendorServiceInput, GetVendorServiceOutput>
    {

        #region Properties

        public int DefaultPageSize => 10;

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public override void DoExecute()
        {
            Parameters = Parameters ?? new GetVendorServiceInput();

            GetVendorServiceOutput output = new GetVendorServiceOutput();
            var predicate = PredicateBuilder.True<VendorService>();
            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(v => v.Id == this.Parameters.Id);
            }
            if (this.Parameters.ServicePeriodPriceId != null)
            {
                predicate = predicate.And(v => v.ServicePeriodPriceId == this.Parameters.ServicePeriodPriceId);
            }
            if (this.Parameters.VendorServicePacketId != null)
            {
                predicate = predicate.And(v => v.VendorServicePacketId == this.Parameters.VendorServicePacketId);
            }
            //predicate = predicate.And(v => v.VendorServicePacket.VendorId == this.Parameters.CurrentUserId);

            if (this.Parameters.ServiceId != null)
            {
                predicate = predicate.And(v => v.ServicePeriodPrice.ServiceId == this.Parameters.ServiceId);
            }
            IQueryable<VendorService> query = Uow.GetRepository<VendorService>().GetAll(predicate);
            var filteredVendorServices = Mapper.Map<List<VendorService>, List<VendorServiceUserDto>>(query.ToList());
            output.VendorServices = filteredVendorServices.ToList();
            Result.Output = output;
        }

        #endregion
    }
}
