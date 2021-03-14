using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Helpers
{
    public enum PaymentMethod : byte
    {
        [Description("Credit Card")]
        CreditCard = 1,

        [Description("Debit Card")]
        DebitCard = 2,

        [Description("In Cash")]
        InCash = 3,
    }
}
