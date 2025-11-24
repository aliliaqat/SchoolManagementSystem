using Microsoft.AspNetCore.Mvc;
using PracticeSMSystem.Data.Enums;

namespace PracticeNewSms.Filters;

public class FeaturePermissionAttribute : TypeFilterAttribute
{
    public FeaturePermissionAttribute(string featureName, AccessLevel required)
        : base(typeof(FeaturePermissionFilter))
    {
        Arguments = new object[] { featureName, required };
    }
}