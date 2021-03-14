using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domains.Helpers;
using Server.Extensions;
using Server.Utilities;

namespace Server.Domains.Models
{
    public class User : ICopyable<User>, ICloneable
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public IList<Purchase> Purchases { get; set; } = new List<Purchase>();

        public object Clone()
        {
            var userCloned = new User { Id = this.Id };
            CopyTo(userCloned);

            return userCloned;
        }

        public void CopyTo(User item)
        {
            item.Name = Name;
            item.Email = Email;
            item.Password = Password;
            item.Cpf = Cpf;
            item.Purchases = (from purchase in Purchases select purchase).ToList();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Email: {Email}";
        }

    }
}
