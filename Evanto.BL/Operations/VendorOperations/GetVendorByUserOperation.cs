using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.VendorOperations
{
    public class GetVendorByUserOperation : Operation<GetVendorByUserInput, GetVendorByUserOutput>
    {
        public override void DoExecute()
        {
            GetVendorByUserOutput output = new GetVendorByUserOutput();
            
            this.Parameters = this.Parameters ?? new GetVendorByUserInput();

            Vendor vendor = this.Uow.GetRepository<Vendor>().Get(v => v.UserId == this.Parameters.VendorId);
            output.Vendor = Mapper.Map<Vendor, VendorUserDto>(vendor);

            Result.Output = output;
        }
    }
}
