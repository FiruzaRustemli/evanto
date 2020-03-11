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
    public class GetUserRatingsByUserOperation : Operation<GetUserRatingsByUserInput, GetUserRatingsByUserOutput>
    {
        public override void DoExecute()
        {
            GetUserRatingsByUserOutput output = new GetUserRatingsByUserOutput();

            VendorService vendorService = this.Uow.GetRepository<VendorService>().Get(v => v.Id == this.Parameters.VendorServiceId);

            if(vendorService == null)
                return;

            var ratings = vendorService.Rating1.Select(r => new VendorServiceRatingUserDto()
            {
                Rating = r.Value,
                Comment = r.Description,
                UserName = r.User.Username,
                FirstName = r.User.FirstName,
                LastName = r.User.LastName
            });

            output.Ratings = ratings.ToList();
            Result.Output = output;
        }
    }
}
