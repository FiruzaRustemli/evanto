//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/01/20 - 23:28:20
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------

using System;

namespace Evanto.BL.DTOs.Core
{
    
    public class UserClaimDto : IDtoBase
    {
         
        public int Id { get; set; }

         
        public int UserId { get; set; }

         
        public int ClaimId { get; set; }

         
        public string Description { get; set; }

         
        public DateTime? CreatedDate { get; set; }

         
        public ClaimDto Claim { get; set; }

         
        public UserDto User { get; set; }
        
    }
}