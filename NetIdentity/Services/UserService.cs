using Microsoft.AspNetCore.Identity;
using NetIdentity.Models;
using System.Security.Claims;

namespace NetIdentity.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserGenderAsync(ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return "Otro";

            var applicationUser = await _userManager.GetUserAsync(user);
            if (applicationUser == null)
                return "Otro";

            // First try to get from claims
            var genderClaim = user.FindFirst("Genero");
            if (genderClaim != null)
                return genderClaim.Value;

            // If not in claims, try to get from user properties
            return applicationUser.Genero ?? "Otro";
        }
    }
}