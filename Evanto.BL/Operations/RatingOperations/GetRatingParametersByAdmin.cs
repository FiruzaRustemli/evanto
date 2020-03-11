using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Admin;

namespace Evanto.BL.Operations.RatingOperations
{
    public class GetRatingInputByAdmin : OperationParameters
    {
       
    }
    public class GetRatingOutputByAdmin
    {
        public List<RatingDto> Ratings { get; set; }
    }
}
