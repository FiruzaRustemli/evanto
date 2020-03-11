using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class RatingUserDto
    {
        public string Rating { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
    }
}
