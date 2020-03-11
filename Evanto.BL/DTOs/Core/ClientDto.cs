using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Core
{
    public class ClientDto : IDtoBase
    {
        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string OAuthClientID { get; set; }
        public string OAuthClientSecret { get; set; }
        public int StatusId { get; set; }
    }
}
