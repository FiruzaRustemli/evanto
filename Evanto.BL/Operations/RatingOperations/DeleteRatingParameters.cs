using System.Collections.Generic;
using Evanto.BL.DTOs.Admin;

namespace Evanto.BL.Operations.RatingOperations
{
    public class DeleteRatingInput : OperationParameters
    {
        public int Id { get; set; }
    }
    public class DeleteRatingOutput
    {
        public bool IsDeleted { get; set; } = false;
    }
}
