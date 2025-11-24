using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using PracticeNewSms.Common;
using PracticeSMSystem.Data.Database;
using PracticeSMSystem.Data.Enums;
using System.Linq;
using System.Security.Claims;

namespace PracticeNewSms.Filters;

public class FeaturePermissionFilter : IAuthorizationFilter
{
    private readonly string _featureName;
    private readonly AccessLevel _required;

    public FeaturePermissionFilter(string featureName, AccessLevel required)
    {
        _featureName = featureName;
        _required = required;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (!user?.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            return;
        }

        var permClaims = user.Claims.Where(c => c.Type == "Permission").Select(c => c.Value).ToList();
        context.HttpContext.Items["permClaims"] = permClaims;
        bool allowed = PermissionEvaluator.IsAllowed(permClaims, _featureName, _required);

        if (!allowed)
        {
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { controller = "Account", action = "AccessDenied" }));
        }
    }
}
