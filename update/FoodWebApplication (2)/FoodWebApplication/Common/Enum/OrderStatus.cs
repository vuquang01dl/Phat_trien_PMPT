using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enum
{
    public enum OrderStatus
    {
        [Description("Ingrogess")]
        Inprocessing = 0,
        [Description("Approve")]
        Approved = 1,
        [Description("Cancel")]
        Cancelled = 2
    }
}
