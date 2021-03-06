using Server.Domains.Helpers;
using Server.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Models
{
  public class Purchase
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public float Value { get; set; }
    public DateTime Date { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PurchaseStatus Status { get; set; }
    public string Observation { get; set; }
    public string Cep { get; set; }
    public string Address { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public IList<PurchaseProduct> PurchaseProducts { get; set; }
  }
}
