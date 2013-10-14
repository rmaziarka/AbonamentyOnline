using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Abon.Interfaces.Services.Portal
{
    public interface IClaimService
    {
        void SignUserInApp(HttpContextBase context, Guid userId, bool isPersistent, IEnumerable<Claim> claims = null);


        void SignUserInApp(HttpContextBase context, string userName, bool isPersistent, IEnumerable<Claim> claims = null);

        void SignUserInApp(HttpContextBase httpContext, string loginProvider, string providerKey, bool isPersistent, IEnumerable<Claim> claims = null);

        Guid GetUserId(IIdentity identity);

        string FindFirstValue(ClaimsIdentity identity, string claimType);
    }
}
