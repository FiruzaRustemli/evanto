//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/01/20 - 23:28:30
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Evanto.BL.DTOs.Core
{
    
    public class VendorDto : IDtoBase
    {
         
        public int UserId { get; set; }

         
        public string Address { get; set; }

         
        public double? Rating { get; set; }

         
        public string Description { get; set; }

         
        public DateTime? CreatedDate { get; set; }

         
        public List<BookingDto> Bookings { get; set; } = new List<BookingDto>();

         
        public List<PaymentDto> Payments { get; set; } = new List<PaymentDto>();

         
        public UserDto User { get; set; }

         
        public List<VendorServicePacketDto> VendorServicePackets { get; set; } = new List<VendorServicePacketDto>();
        
    }
}