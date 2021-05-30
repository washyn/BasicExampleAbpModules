using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace WebApplicationMvc.CustomHandler
{
    public class RolesAuthorizationHandler :
        AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            RolesAuthorizationRequirement requirement)
        {
            
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
            // 
            else
            {
                var claims = context.User.Claims;
                
                // var userName = claims.FirstOrDefault(c => c.Type == "UserName").Value;
                // var userId = claims.FirstOrDefault(c => c.Type == "UserId").Value;
                
                var userRol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                
                var roles = requirement.AllowedRoles;
                // se probara manualmente los roles, no se obtendra de base de datos
                // modificar y ver si el rol esta en el usuario
                
                
                // TODO: agregar codigo para validar el rol...
                // validRole = new Users().GetUsers().Where(p => roles.Contains(p.Role) && p.UserName == userName).Any();
                
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