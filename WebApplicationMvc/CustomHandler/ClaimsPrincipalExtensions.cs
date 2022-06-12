using System;
using System.Security.Claims;

namespace WebApplicationMvc.CustomHandler
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            return principal.FindFirstValue("FullName");
        }
        
        public static string GetRol(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            return principal.FindFirstValue(ClaimTypes.Role);
        }
    }
}