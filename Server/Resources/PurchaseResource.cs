using Server.Domains.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Resources
{
  public class PurchaseResource
  {
    public int Id { get; set; }
    public float Value { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PurchaseStatus Status { get; set; }
    public string Observation { get; set; }
    public String Cep { get; set; }
    public string Address { get; set; }
    public int UserId { get; set; }

    public IList<PurchaseProductResource> PurchaseProducts { get; set; }
  }
}
