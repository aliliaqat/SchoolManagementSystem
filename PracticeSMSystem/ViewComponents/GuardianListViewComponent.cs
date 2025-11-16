using Microsoft.AspNetCore.Mvc;
using PracticeSMSystem.Data.Models; 
using System.Collections.Generic;

namespace PracticeNewSms.ViewComponents;

public class GuardianListViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(IEnumerable<Guardian> guardians)
    {
        var safeList = guardians ?? new List<Guardian>();
        return View("GuardianList", safeList);
    }
}
