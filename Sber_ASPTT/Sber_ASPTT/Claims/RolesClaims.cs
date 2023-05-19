using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Sber_ASPTT.Claims
{
    public class RolesClaims : IClaimsTransformation
    {
        private readonly ApplicationContext _context;
        public RolesClaims(ApplicationContext context)
        {
            _context = context;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var claiminfo = (ClaimsIdentity)principal.Identity;
            //performing operation for getting only windows username which is stored in database
            string Name = claiminfo.Name;

            var role = _context.UserRoles.FirstOrDefault(t=> t.UserName == Name)?.RoleName;  
            if(string.IsNullOrEmpty(role))
                return Task.FromResult(principal);
            var c = new Claim(claiminfo.RoleClaimType, role);
            claiminfo.AddClaim(c);
            return Task.FromResult(principal);
        }
    }
}