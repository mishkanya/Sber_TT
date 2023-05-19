using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Sber_ASPTT
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity == null || !filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/");
            }

            var user = filterContext.HttpContext.User;
            if (string.IsNullOrEmpty(Roles))
                return;
            if (!user.IsInRole(Roles))
            {
                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}
