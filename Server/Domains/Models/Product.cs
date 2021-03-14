using Server.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Models
{
    public class Product : ICopyable<Product>, ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public string Observation { get; set; }
        public IList<Purchase> Purchases { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public object Clone()
        {
            var clonedProduct = new Product { Id = this.Id };
            CopyTo(clonedProduct);

            return clonedProduct;
        }

        public void CopyTo(Product item)
        {
            item.Name = Name;
            item.Description = Description;
            item.Value = Value;
            item.Observation = Observation;
            item.Purchases = (from purchase in Purchases select purchase).ToList();
            item.CompanyId = CompanyId;
            item.Company = Company.Clone() as Company;
        }
    }
}
