using Server.Domains.Helpers;
using Server.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Models
{
    public class Purchase : ICopyable<Purchase>
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PurchaseStatus Status { get; set; }
        public string Observation { get; set; }
        public String Cep { get; set; }
        public string Address { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public void CopyTo(Purchase item)
        {
            item.Value = Value;
            item.Date = Date;
            item.PaymentMethod = PaymentMethod;
            item.Status = Status;
            item.Observation = Observation;
            item.Cep = Cep;
            item.Address = Address;
            item.User = User.Clone() as User;
            item.UserId = UserId;
            item.ProductId = ProductId;
            item.Product = Product.Clone() as Product;
        }
    }
}
