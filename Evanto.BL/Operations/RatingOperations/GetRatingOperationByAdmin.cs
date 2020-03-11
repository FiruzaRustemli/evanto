using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.RatingOperations
{
    public class GetRatingOperationByAdmin : Operation<GetRatingInputByAdmin, GetRatingOutputByAdmin>
    {
        public override void DoExecute()
        {
            GetRatingOutputByAdmin output = new GetRatingOutputByAdmin { Ratings = new List<RatingDto>() };
            var predicate = PredicateBuilder.True<Rating>();
          
            var ratings = this.Uow.GetRepository<Rating>().GetAll(predicate).ToList();
            var returnedData = Mapper.Map<List<Rating>, List<RatingDto>>(ratings);
            for (int i = 0; i < ratings.Count; i++)
            {
                returnedData[i].UserName = ratings[i].User.Username;
                returnedData[i].VendorService = ratings[i].VendorService.Name;
            }
            output.Ratings = returnedData;
            Result.Output = output;
        }
    }
}
