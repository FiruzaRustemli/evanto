using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Admin.Models
{
    public class EmailSender
    {
        public string Content { get; set; }
        public string Subject { get; set; }
        public string UserEmail { get; set; }
    }
}
