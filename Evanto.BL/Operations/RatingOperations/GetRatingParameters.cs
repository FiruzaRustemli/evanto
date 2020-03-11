using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Admin;

namespace Evanto.BL.Operations.RatingOperations
{
    public class GetRatingInput : OperationParameters
    {
       
    }
    public class GetRatingOutput
    {
        public List<RatingDto> Ratings { get; set; }
    }
}
