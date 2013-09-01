using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services.Interfaces
{
    public interface IClaimService
    {
        void SignIn(HttpContextBase context, Guid userId, IEnumerable<Claim> claims, bool isPersistent);
        
        void SignIn(HttpContextBase context, Guid userId, bool isPersistent);

        void SignIn(HttpContextBase httpContext, string userName, bool isPersistent);
    }
}
