using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace WebApplicationMvc.CustomHandler
{
    /// <summary>
    /// Clase encargada de verifiar los roles
    /// </summary>
    public class RolesAuthorizationHandler :
        AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            RolesAuthorizationRequirement requirement)
        {
            
            // se verifica si esta autenticado
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }


            var validRole = false;
            
            // si la colecion de roles es nulo o no hay uno
            // valid role, true
            // para que pueda acceder si no esta especificado el rol en el authorize
            if (requirement.AllowedRoles == null || 
                requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            // en caso hay roles en la coleccion
            else
            {
                var claims = context.User.Claims;
                var userRol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                var roles = requirement.AllowedRoles;
                // si el claim de rol esta, en el authorize(roles ...)
                validRole = roles.Contains(userRol);
            }

            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}