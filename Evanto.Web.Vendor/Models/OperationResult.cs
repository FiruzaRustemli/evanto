using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evanto.Web.Vendor.Models
{
    public class OperationResult<TResult> where TResult : class
    {
        public TResult output { get; set; }
        public List<Error> errorList { get; set; } = new List<Error>();
        public bool isSuccess { get; set; }
    }
}