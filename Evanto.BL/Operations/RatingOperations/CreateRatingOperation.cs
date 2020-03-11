using System;
using System.Collections.Generic;
using Evanto.BL.Operations.PaymentOperations;
using Evanto.DAL.Context;
using System.Linq;
using Evanto.Utils;

namespace Evanto.BL.Operations.RatingOperations
{
    public class CreateRatingOperation : Operation<CreateRatingInput, CreateRatingOutput>
    {
        public override void DoExecute()
        {
            var existingRating = this
                                    .Uow
                                    .GetRepository<Rating>()
                                    .Get(r => r.UserId == this.Parameters.CurrentUserId 
                                           && r.VendorServiceId == this.Parameters.VendorServiceId);

            if (existingRating != null)
            {
                //TODO: Do error implementation here.

                Result.ErrorList = new List<Error>
                {
                    new Error
                    {
                        Text = "You have already rated this vendor."
                    }
                };

                return;
            }

            Rating givenRating = Mapper.Map<CreateRatingInput, Rating>(this.Parameters);

            this.Uow.GetRepository<Rating>().Add(givenRating);
            this.Uow.SaveChanges();
            // Updates Vendorservice rating

            var vendorService = this.Uow.GetRepository<VendorService>().GetById(this.Parameters.VendorServiceId);
            var vendorServiceRatings = vendorService.Rating1;
            var vendorServiceRatingsCount = vendorServiceRatings.Count;
            double vendorServiceRatingsSum = vendorService.Rating1.Sum(r => r.Value);

            vendorService.Rating = vendorServiceRatingsSum / vendorServiceRatingsCount;

            this.Uow.GetRepository<VendorService>().Update(vendorService);
            this.Uow.SaveChanges();

            Result.Output = new CreateRatingOutput();
        }
    }
}
