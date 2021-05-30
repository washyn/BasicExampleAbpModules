﻿using System;
using System.Security.Claims;

namespace WebApplicationMvc.CustomHandler
{
    public static class ClaimsPrincipalExtensions
    {
        // public static T GetLoggedInUserId<T>(this ClaimsPrincipal principal)
        // {
        //     if (principal == null)
        //         throw new ArgumentNullException(nameof(principal));
        //
        //     var loggedInUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        //
        //     if (typeof(T) == typeof(string))
        //     {
        //         return (T)Convert.ChangeType(loggedInUserId, typeof(T));
        //     }
        //     else if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
        //     {
        //         return loggedInUserId != null ? (T)Convert.ChangeType(loggedInUserId, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
        //     }
        //     else
        //     {
        //         throw new Exception("Invalid type provided");
        //     }
        // }

        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            // return principal.FindFirstValue(ClaimTypes.Name);
            return principal.FindFirstValue("FullName");
        }

        // public static string GetLoggedInUserEmail(this ClaimsPrincipal principal)
        // {
        //     if (principal == null)
        //         throw new ArgumentNullException(nameof(principal));
        //
        //     return principal.FindFirstValue(ClaimTypes.Email);
        // }
    }
}