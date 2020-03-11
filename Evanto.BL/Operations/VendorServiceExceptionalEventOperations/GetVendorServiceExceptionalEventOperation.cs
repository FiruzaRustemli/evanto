using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.VendorServiceExceptionalEventOperations
{
    public class GetVendorServiceExceptionalEventOperations : Operation<GetVendorServiceExceptionalEventInput, GetVendorServiceExceptionalEventOutput>
    {
        public override void DoExecute()
        {
            GetVendorServiceExceptionalEventOutput output = new GetVendorServiceExceptionalEventOutput();
            output.VendorExceptionalEvents = new List<VendorServiceExceptionalEventDto>();
            var predicate = PredicateBuilder.True<VendorServiceExceptionalEvent>();
            if(this.Parameters.Id != null)
            {
                predicate = predicate.And(v => v.Id == this.Parameters.Id);
            }
            if (this.Parameters.EventId != null)
            {
                predicate = predicate.And(v => v.EventId == this.Parameters.EventId);
            }
            if (this.Parameters.VendorServiceId != null)
            {
                predicate = predicate.And(v => v.VendorServiceId == this.Parameters.VendorServiceId);
            }
            if(this.Parameters.CreatedDate != DateTime.MinValue)
            {
                predicate = predicate.And(v => v.CreatedDate == this.Parameters.CreatedDate);
            }
            var vsees = this.Uow.GetRepository<VendorServiceExceptionalEvent>().GetAll(predicate).ToList();
            output.VendorExceptionalEvents =
                Mapper.Map<List<VendorServiceExceptionalEvent>, List<VendorServiceExceptionalEventDto>>(vsees);
            Result.Output = output;
        }
    }
}
