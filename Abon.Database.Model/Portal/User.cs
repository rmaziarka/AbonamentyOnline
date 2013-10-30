using System.Collections.Generic;

namespace Abon.Database.Model.Portal
{
    public class User:ModelBase
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public virtual UserSecret UserSecret { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
