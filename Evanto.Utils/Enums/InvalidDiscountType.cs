using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Utils.Enums
{
    public enum InvalidDiscountType
    {
        Valid = 0,
        NotFound = 1,
        Expired = 2,
        InvalidStatus = 3,
        Other = 4
    }
}
