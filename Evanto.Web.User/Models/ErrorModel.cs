using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.User.Models
{
    public class ErrorModel
    {
        public string Error { get; set; }
        public List<Evanto.Utils.Error> Error_description { get; set; }
    }
}
