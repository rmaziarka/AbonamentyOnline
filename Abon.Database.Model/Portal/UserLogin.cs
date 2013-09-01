using System;

namespace Abon.Database.Model.Portal
{
    public class UserLogin:ModelBase
    {
        public Guid UserId { get; set; }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public virtual User User { get; set; }
    }
}
