using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Enums;

namespace SecureWebAPI.AuthAttributes
{
    public class AuthAttributes : Attribute, IAuthorizationFilter
    {
        private readonly Permissions _permission;

        public AuthAttributes(Permissions permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user == null || !user.Claims.Any(c => c.Type == "Permission" && c.Value == _permission.ToString()))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();
            }
        }
    }
}
