using PracticeSMSystem.Data.Enums;

namespace PracticeNewSms.Common
{
    public class PermissionEvaluator
    {
        public static bool IsAllowed(List<string> permClaims, string _featureName, AccessLevel _required)
        {
            bool allowed = permClaims.Any(p =>
            {
                var parts = p.Split(':');
                if (parts.Length != 2) return false;

                if (!parts[0].Equals(_featureName, StringComparison.OrdinalIgnoreCase))
                    return false;

                if (!int.TryParse(parts[1], out int level)) return false;

                // ⚡ Bitwise check for Flags enum
                return ((AccessLevel)level & _required) == _required;
            });
            return allowed;
        }
    }
}
