using System;
using System.Collections.Generic;

namespace Evanto.BL.DTOs.Core
{
    public partial class ClaimDto
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public DateTime? CreatedDate { get; set; }

        
        public List<UserClaimDto> UserClaims { get; set; } = new List<UserClaimDto>();
        
    }
}