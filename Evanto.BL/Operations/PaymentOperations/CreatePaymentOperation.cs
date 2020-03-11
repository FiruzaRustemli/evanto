using System;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.PaymentOperations
{
    public class CreatePaymentOperation : Operation<CreatePaymentInput, CreatePaymentOutput>
    {
        public override void DoExecute()
        {
            Payment payment = Mapper.Map<CreatePaymentInput, Payment>(this.Parameters);
            Result.Output = new CreatePaymentOutput();
            payment.PaymentDate = DateTime.UtcNow.AddHours(4);
            payment.CreatedDate = DateTime.UtcNow.AddHours(4);
            this.Uow.GetRepository<Payment>().Add(payment);
            this.Uow.SaveChanges();
            Result.Output.IsCreated = true;
            Result.Output.PaymentId = payment.Id;
        }
    }
}
