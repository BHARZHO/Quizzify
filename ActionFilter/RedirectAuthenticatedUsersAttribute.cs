using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Quiziffy.ActionFilter
{
    public class RedirectAuthenticatedUsersAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity!.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Index", "Team", null);
            }
        }
    }
}
