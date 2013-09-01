using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Abon.Database;
using Abon.Database.Model.Portal;
using Microsoft.Owin.Host.SystemWeb;
using Services.Interfaces;
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


        public void SignIn(HttpContextBase context, Guid userId, IEnumerable<Claim> claims, bool isPersistent)
        {
            var user = _unitOfWork.Repository<User>().GetById(userId);
            if (user == null)
                return;

            // Replace UserIdentity claims with the application specific claims
            IList<Claim> userClaims = RemoveUserIdentityClaims(claims);
            AddUserIdentityClaims(user.Id.ToString(), user.Name, userClaims);
            SignIn(context, userClaims, isPersistent);
        }

        public void SignIn(HttpContextBase context, string userName, bool isPersistent)
        {

            User user = _unitOfWork
                .Repository<User>()
                .All()
                .FirstOrDefault(el => el.Name == userName);

            if (user == null) 
                return;

            var claims = new List<Claim>();
            // Replace UserIdentity claims with the application specific claims
            IList<Claim> userClaims = RemoveUserIdentityClaims(claims);
            AddUserIdentityClaims(user.Id.ToString(), user.Name, userClaims);
            SignIn(context, userClaims, isPersistent);
        }

        public void SignIn(HttpContextBase context, Guid userId, bool isPersistent)
        {
            SignIn(context, userId,new List<Claim>(),isPersistent );
        }

        private IList<Claim> RemoveUserIdentityClaims(IEnumerable<Claim> claims)
        {
            List<Claim> filteredClaims = new List<Claim>();
            foreach (var c in claims)
            {
                // Strip out any existing name/nameid claims
                if (c.Type != ClaimTypes.Name &&
                    c.Type != ClaimTypes.NameIdentifier)
                {
                    filteredClaims.Add(c);
                }
            }
            return filteredClaims;
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


        private void SignIn(HttpContextBase context, IEnumerable<Claim> userClaims, bool isPersistent)
        {
            context.SignIn(userClaims, ClaimTypes.Name, RoleClaimType, isPersistent);
        }
    }
}
