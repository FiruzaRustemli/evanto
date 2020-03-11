using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Xml.Serialization;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL
{
    public class OperationResult<TResult> where TResult: class
    {
        public TResult Output { get;set;}        
        public List<Error> ErrorList { get; set; } = new List<Error>();
        public bool IsSuccess => !ErrorList.Any();
    }
}
