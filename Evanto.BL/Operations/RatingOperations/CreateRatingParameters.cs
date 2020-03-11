using System;

namespace Evanto.BL.Operations.RatingOperations
{
    public class CreateRatingInput : OperationParameters
    {
        public int VendorServiceId { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public int VendorId { get; set; }
    }
    public class CreateRatingOutput
    {

    }
}
