using System.ComponentModel.DataAnnotations;

namespace Evanto.BL.Operations.ServicePeriodPriceOperations
{
    public class CreateServicePeriodPriceInput : OperationParameters
    {
        [Required(ErrorMessage = "Id is Required")]
        [Range(1,int.MaxValue,ErrorMessage = "Id must be integer")]
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

    public class CreateServicePeriodPriceOutput
    {
        public bool IsCreated { get; set; }
    }
}
