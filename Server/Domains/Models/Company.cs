using Server.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Models
{
    public class Company : ICloneable, ICopyable<Company>
    {
        public int Id { get; set; }
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public IList<Product> Products { get; set; }

        public object Clone()
        {
            var clonedCompany = new Company { Id = this.Id };
            CopyTo(clonedCompany);

            return clonedCompany;
        }

        public void CopyTo(Company item)
        {
            item.FantasyName = FantasyName;
            item.CompanyName = CompanyName;
            item.Cnpj = Cnpj;
            item.Products = (from product in Products select product).ToList();
        }
    }
}
