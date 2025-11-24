using Microsoft.AspNetCore.Mvc;
using PracticeNewSms.Common;

namespace PracticeNewSms.Controllers
{
    public class BaseController : Controller
    {
        //public readonly List<string> permClaims;
        public BaseController()
        {
            //if (HttpContext != null)
            //{
            //    var _usr = User;
            //    var user = HttpContext.User;
            //    if (!user?.Identity?.IsAuthenticated ?? true)
            //    {
            //        RedirectToAction("Login", "Account");
            //        //context.Result = new RedirectToRouteResult(
            //        //    new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            //        //return;
            //    }
            //    permClaims = user.Claims.Where(c => c.Type == "Permission").Select(c => c.Value).ToList();
            //}
        }
    }
}
