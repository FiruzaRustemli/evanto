using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.DAL.Context;

namespace Evanto.BL.DTOs.Public
{
    public class VendorPublicDto
    {
        public int UserId { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public UserPublicDto User { get; set; }
    }
}
