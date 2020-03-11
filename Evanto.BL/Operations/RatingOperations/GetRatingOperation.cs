using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.RatingOperations
{
    public class GetRatingOperation : Operation<GetRatingInput, GetRatingOutput>
    {
        public override void DoExecute()
        {
            GetRatingOutput output = new GetRatingOutput { Ratings = new List<RatingDto>() };
            var predicate = PredicateBuilder.True<Rating>();
          
            var ratings = this.Uow.GetRepository<Rating>().GetAll(predicate).ToList();
            var returnedData = Mapper.Map<List<Rating>, List<RatingDto>>(ratings);
            
            output.Ratings = returnedData;
            Result.Output = output;
        }
    }
}
