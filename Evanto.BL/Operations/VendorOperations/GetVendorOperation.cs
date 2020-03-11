using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.VendorOperations
{
    public class GetVendorOperation : Operation<GetVendorInput, GetVendorOutput>
    {
        public override void DoExecute()
        {
            GetVendorOutput output = new GetVendorOutput();
            output.Vendors = new List<AdminVendorDto>();
            var predicate = PredicateBuilder.True<Vendor>();
            if (this.Parameters == null)
            {
                this.Parameters = new GetVendorInput();
            }
            if (this.Parameters.UserId != null)
            {
                predicate = predicate.And(v => v.UserId == this.Parameters.UserId);
            }
            if (!String.IsNullOrEmpty(this.Parameters.Address))
            {
                predicate = predicate.And(v => v.Address == this.Parameters.Address);
            }
            if (this.Parameters.CreatedDate != DateTime.MinValue)
            {
                predicate = predicate.And(v => v.CreatedDate == this.Parameters.CreatedDate);
            }
            List<Vendor> vendorList = this.Uow.GetRepository<Vendor>().GetAll(predicate, "User").ToList();
            output.Vendors = Mapper.Map<List<Vendor>, List<AdminVendorDto>>(vendorList);
            Result.Output = output;
        }
    }
}
