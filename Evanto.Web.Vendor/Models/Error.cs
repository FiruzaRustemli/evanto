using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evanto.Web.Vendor.Models
{
    public class Error
    {
        public int Type { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
    }
}