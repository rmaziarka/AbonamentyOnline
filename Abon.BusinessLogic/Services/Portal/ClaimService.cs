using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Abon.Database;
using Abon.Database.Model.Portal;
using Microsoft.Owin.Host.SystemWeb;
using System.Web.Helpers;
using Microsoft.Owin;

namespace Abon.BusinessLogic.Services.Portal
{
    public class ClaimService:IClaimService
    {
        private IUnitOfWork _unitOfWork;
        public static string RoleClaimType { get; set; }
        public static string UserNameClaimType { get; set; }
        public static string UserIdClaimType { get; set; }
        public static string ClaimsIssuer { get; set; }


        public ClaimService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RoleClaimType = ClaimsIdentity.DefaultRoleClaimType;
            UserIdClaimType = "http://schemas.microsoft.com/aspnet/userid";
            UserNameClaimType = "http://schemas.microsoft.com/aspnet/username";
            ClaimsIssuer = ClaimsIdentity.DefaultIssuer;
            AntiForgeryConfig.UniqueClaimTypeIdentifier = UserIdClaimType;
        }



        public void SignUserInApp(HttpContextBase context, Guid userId,  bool isPersistent,IEnumerable<Claim> claims = null)
        {
            var user = _unitOfWork.Repository<User>().GetById(userId);
            if (user == null)
                return;

            SignUserInApp(context, user, isPersistent, claims);
        }

        public void SignUserInApp(HttpContextBase context, string userName, bool isPersistent, IEnumerable<Claim> claims = null)
        {
            var user = _unitOfWork
                .Repository<User>()
                .All()
                .FirstOrDefault(el => el.Name == userName);

            if (user == null) 
                return;

            SignUserInApp(context, user, isPersistent, claims);
        }

        public void SignUserInApp(HttpContextBase context, string loginProvider, string providerKey, bool isPersistent,
            IEnumerable<Claim> claims = null)
        {
            var user = _unitOfWork.Repository<User>()
                .All()
                .FirstOrDefault(
                    el => el.UserLogins.Any(
                        ul => ul.LoginProvider
                        == loginProvider && ul.ProviderKey == providerKey
                        ));

            if (user == null)
                return;

            SignUserInApp(context, user, isPersistent, claims);
        }


        public  Guid GetUserId(IIdentity identity)
        {
            var ci = identity as ClaimsIdentity;

            if (ci == null) return Guid.Empty;

            var stringId = FindFirstValue(ci,UserIdClaimType);
            return Guid.Parse(stringId);
        }

        public string FindFirstValue(ClaimsIdentity identity, string claimType)
        {
            var claim = identity.FindFirst(claimType);

            return claim != null ? claim.Value : null;
        }



        private void SignUserInApp(HttpContextBase context, User user, bool isPersistent, IEnumerable<Claim> claims)
        {
            if (claims == null)
                claims = new List<Claim>();

            IList<Claim> userClaims = RemoveUserIdentityClaims(claims);
            AddUserIdentityClaims(user.Id.ToString(), user.Name, userClaims);
            SignInContext(context, userClaims, isPersistent);
        }


        private IList<Claim> RemoveUserIdentityClaims(IEnumerable<Claim> claims)
        {
            return claims.Where(c => c.Type != ClaimTypes.Name && c.Type != ClaimTypes.NameIdentifier).ToList();
        }

        private void AddRoleClaims(IEnumerable<string> roles, IList<Claim> claims)
        {
            foreach (string role in roles)
            {
                claims.Add(new Claim(RoleClaimType, role, ClaimsIssuer));
            }
        }

        private void AddUserIdentityClaims(string userId, string displayName, IList<Claim> claims)
        {
            claims.Add(new Claim(ClaimTypes.Name, displayName, ClaimsIssuer));
            claims.Add(new Claim(UserIdClaimType, userId, ClaimsIssuer));
            claims.Add(new Claim(UserNameClaimType, displayName, ClaimsIssuer));
        }


        private void SignInContext(HttpContextBase context, IEnumerable<Claim> userClaims, bool isPersistent)
        {
            context.SignIn(userClaims, ClaimTypes.Name, RoleClaimType, isPersistent);
        }
    }
}
