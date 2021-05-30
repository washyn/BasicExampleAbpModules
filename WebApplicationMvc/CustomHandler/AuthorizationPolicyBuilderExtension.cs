using Microsoft.AspNetCore.Authorization;

namespace WebApplicationMvc.CustomHandler
{
    public static class AuthorizationPolicyBuilderExtension
    {
        // para policy, aunque no se pretende usar esto
        //
        // public static AuthorizationPolicyBuilder UserRequireCustomClaim(this AuthorizationPolicyBuilder builder, string claimType)  
        // {  
        //     builder.AddRequirements(new CustomUserRequireClaim(claimType));  
        //     return builder;  
        // } 
    }
}