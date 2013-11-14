using System;
using System.Collections.Generic;

namespace Abon.Database.Model.Portal
{
    public class User:ModelBase
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public virtual Address Address { get; set; }
        public Guid AddressId { get; set; }

        public virtual UserSecret UserSecret { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
