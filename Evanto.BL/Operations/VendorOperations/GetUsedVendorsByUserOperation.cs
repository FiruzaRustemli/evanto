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
    public class GetUsedVendorsByUserOperation : Operation<GetUsedVendorsByUserInput, GetUsedVendorsByUserOutput>
    {
        public override void DoExecute()
        {
            GetUsedVendorsByUserOutput output = new GetUsedVendorsByUserOutput();

            var predicate = PredicateBuilder.True<Vendor>();
            this.Parameters = this.Parameters ?? new GetUsedVendorsByUserInput();

            predicate = predicate.And(v => v.Booking.Any(b => b.UserId == this.Parameters.CurrentUserId));


            List<UsedVendorUserDto> vendorList = this.Uow.GetRepository<Vendor>().GetAll(predicate, "User").AsEnumerable().Select(v => new UsedVendorUserDto
            {
                User = Mapper.Map<User, VendorUserUserDto>(v.User),
                UserId = v.UserId,
                Address = v.Address,
                WaitingRequestCount = v.Booking.Count(b => b.UserId == this.Parameters.CurrentUserId && b.StatusId == 1),
                ConfirmedRequestCount = v.Booking.Count(b => b.UserId == this.Parameters.CurrentUserId && b.StatusId == 2),
                RejectedRequestCount = v.Booking.Count(b => b.UserId == this.Parameters.CurrentUserId && b.StatusId == 3),
            }).ToList();


            output.Vendors = vendorList;
            Result.Output = output;
        }
    }
}
