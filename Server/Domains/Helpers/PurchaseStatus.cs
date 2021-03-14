using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Helpers
{
    public enum PurchaseStatus : byte
    {
        [Description("Order issued")]
        Issued = 1,

        [Description("Order Confirmed")]
        Confirmed = 2,

        [Description("Order on delivery")]
        Delivery = 3,

        [Description("Order Completed")]
        Done = 4,

        [Description("Order canceled")]
        Canceled = 5
    }
}
