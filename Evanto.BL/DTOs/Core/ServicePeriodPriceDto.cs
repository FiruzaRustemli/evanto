//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/01/20 - 23:28:10
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Evanto.DAL.Context;

namespace Evanto.BL.DTOs.Core
{
    
    public class ServicePeriodPriceDto : IDtoBase
    {
         
        public int Id { get; set; }

         
        public int ServiceId { get; set; }

         
        public int PeriodId { get; set; }

         
        public double Price { get; set; }

         
        public DateTime? CreatedDate { get; set; }

         
        public PeriodDto Period { get; set; }

         
        public ServiceDto Service { get; set; }

         
        public List<VendorServiceDto> VendorServices { get; set; } = new List<VendorServiceDto>();
        
    }
}