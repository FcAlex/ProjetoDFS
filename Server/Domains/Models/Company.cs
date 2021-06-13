using Server.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string imageURL {get; set;}
        public IList<Product> Products { get; set; }

    }
}
