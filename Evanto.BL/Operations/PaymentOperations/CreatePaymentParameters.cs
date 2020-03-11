using System;

namespace Evanto.BL.Operations.PaymentOperations
{
    public class CreatePaymentInput : OperationParameters
    {
        public int VendorId { get; set; }
        public int StatusId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentTypeId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class CreatePaymentOutput
    {
        public bool IsCreated { get; set; }
        public int PaymentId { get; set; }
    }
}
