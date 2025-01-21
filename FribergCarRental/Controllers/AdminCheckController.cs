using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FribergCarRental.Controllers
{
    public class AdminCheckController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = context.HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(role) || role != "Admin")
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
