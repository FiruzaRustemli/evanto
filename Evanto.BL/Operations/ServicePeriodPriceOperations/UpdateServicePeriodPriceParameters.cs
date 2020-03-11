using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.ServicePeriodPriceOperations
{
    public class UpdateServicePeriodPriceInput : OperationParameters
    {
        [Required(ErrorMessage = "Id is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be integer")]
        public int Id { get; set; }

        [Required(ErrorMessage = "ServiceId is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "ServiceId must be integer")]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "ServiceId is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "ServiceId must be integer")]
        public int PeriodId { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }
    }
    public class UpdateServicePeriodPriceOutput
    {
        public ServicePeriodPriceDto ServicePeriodPrice { get; set; }
        public bool IsUpdated { get; set; }
    }
}
