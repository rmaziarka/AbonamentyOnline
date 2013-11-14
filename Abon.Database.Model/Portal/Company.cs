using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Database.Model.Portal
{
    public class Company:ModelBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Regon { get; set; }

        public string Phone { get; set; }

        public string Nip { get; set; }

        public string Email { get; set; }

        public virtual Image Logo { get; set; }
        public Guid LogoId { get; set; }

        public virtual Address Address { get; set; }
        public Guid AddressId { get; set; }

        public virtual Address ContactAddress { get; set; }
        public Guid? ContactAddressId { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
