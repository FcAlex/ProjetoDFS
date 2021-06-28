using Server.Domains.Helpers;
using Server.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Models
{
  public class PurchaseProduct
  {
    public int ProductId { get; set; }
    public int PurchaseId { get; set; }
    public Purchase Purchase { get; set; }
    public Product Product { get; set; }

  }
}
