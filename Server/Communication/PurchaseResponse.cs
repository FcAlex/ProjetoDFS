using Server.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Communication
{
    public class PurchaseResponse : BaseResponse
    {
        public Purchase Purchase { get; set; }

        private PurchaseResponse(bool success, string message, Purchase purchase) : base(success, message) { }

        public PurchaseResponse(Purchase purchase) : this(true, string.Empty, purchase) { }

        public PurchaseResponse(string message) : this(false, message, null) { }
    }
}
