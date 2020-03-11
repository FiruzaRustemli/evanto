using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.PaymentOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Core
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<CreatePaymentInput, Payment>();
            CreateMap<Payment, CreatePaymentInput>();
            CreateMap<Payment, PaymentDto>();
        }
    }
}
