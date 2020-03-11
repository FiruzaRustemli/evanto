using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.ServicePeriodPriceOperations
{
    public class GetServicePeriodPriceOperation : Operation<GetServicePeriodPriceInput, GetServicePeriodPriceOutput>
    {
        public override void DoExecute()
        {
            GetServicePeriodPriceOutput output = new GetServicePeriodPriceOutput
            {
                ServicePeriodPricesGrouped = new List<ServicePeriodPricesGroupedVendorDto>()
            };
            List<ServicePeriodPricesGroupedVendorDto> servicePeriodPriceGroupDtos = new List<ServicePeriodPricesGroupedVendorDto>();

            var servicePeriodPriceGroupedList = this.Uow.GetRepository<ServicePeriodPrice>()
                .GetAll(s => true, "Service", "Period").ToList().GroupBy(p => p.ServiceId);
            foreach (var item in servicePeriodPriceGroupedList)
            {
                ServicePeriodPricesGroupedVendorDto model = new ServicePeriodPricesGroupedVendorDto();
                model.GroupById = item.Key;
                foreach (var i in item)
                {
                    model.ServicePeriodPrices
                        .Add(Mapper.Map<ServicePeriodPrice, ServicePeriodPriceVendorDto>(i));
                }
                servicePeriodPriceGroupDtos.Add(model);
            }

            output.ServicePeriodPricesGrouped = servicePeriodPriceGroupDtos;
            Result.Output = output;
        }
    }
}
