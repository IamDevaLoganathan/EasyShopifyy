using EasyShopify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace EasyShopify.Utilities
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
         RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> opotions) : base(userManager, roleManager, opotions)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var Identity = await base.GenerateClaimsAsync(user);
            Identity.AddClaim(new Claim("Name", user.Name));
            return Identity;
        }
    }
}
