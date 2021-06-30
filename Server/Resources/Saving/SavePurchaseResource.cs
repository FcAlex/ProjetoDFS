using Server.Domains.Helpers;
using Server.Domains.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Resources.Saving
{
  public class SavePurchaseResource
  {
    [Required]
    public float Value { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [EnumDataType(typeof(PaymentMethod))]
    public PaymentMethod PaymentMethod { get; set; }

    [Required]
    [EnumDataType(typeof(PurchaseStatus))]
    public PurchaseStatus Status { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Observation { get; set; }

    [Required]
    [RegularExpression(@"\d{2}\.\d{3}\-\d{3}", ErrorMessage = "The CEP field must match the standard: xx.xxx-xxx")]
    public String Cep { get; set; }

    [Required]
    [StringLength(50)]
    public string Address { get; set; }

    [Required]
    public int UserId { get; set; }

    public IList<PurchaseProductResource> PurchaseProducts { get; set; }
  }
}
