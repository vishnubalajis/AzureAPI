using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AzureAPI.Filters
{
    public class PermissionHandler :AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
           AuthorizationHandlerContext context,
           PermissionRequirement requirement)
        {
            // In MVC, Resource is AuthorizationFilterContext
            var mvcContext = context.Resource as AuthorizationFilterContext;

            if (mvcContext == null)
                return Task.CompletedTask;

            var routeData = mvcContext.RouteData;
            var controller = routeData.Values["controller"]?.ToString();
            var action = routeData.Values["action"]?.ToString();

            // Build required permission dynamically
            var requiredPermission = $"{controller}.{action}";

            // Get permissions from JWT claims
            var userPermissions = context.User.FindAll("Permission");

            if (userPermissions.Any(p => p.Value == requiredPermission))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
