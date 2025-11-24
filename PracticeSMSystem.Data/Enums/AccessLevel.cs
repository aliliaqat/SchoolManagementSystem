using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSMSystem.Data.Enums;

[Flags]
public enum AccessLevel
{
    None = 0,
    View = 1 << 0, // 1
    Details = 1 << 1, // 2  <-- new
    Create = 1 << 2, // 4
    Edit = 1 << 3, // 8
    Delete = 1 << 4,  // 16
    StudentGuardian = 1 << 5,  // 32
    AddStudents = 1 << 6,  // 64
    Manage = 1 << 7,  // 128
    UpdatePermissions = 1 << 8,  // 256
    Save = 1 << 9,  // 512
    SetAuditFields = 1 << 10,  // 1024
    CopyStaffFields = 1 << 11  // 2048
}
