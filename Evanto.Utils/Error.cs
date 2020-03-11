using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.Utils.Enums;

namespace Evanto.Utils
{
    public class Error
    {
        #region Properties

        public OperationResultCode Type { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }

        #endregion
    }
}
