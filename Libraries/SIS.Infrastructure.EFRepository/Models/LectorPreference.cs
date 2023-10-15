using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class LectorPreference
{
    public int LectorPreferenceId { get; set; }

    public int Preference { get; set; }

    public string? Description { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual ICollection<LectorCoordinationRoleInterest> LectorCoordinationRoleInterests { get; set; } = new List<LectorCoordinationRoleInterest>();

    public virtual ICollection<LectorCourseInterest> LectorCourseInterests { get; set; } = new List<LectorCourseInterest>();

    public virtual ICollection<LectorLocationInterest> LectorLocationInterests { get; set; } = new List<LectorLocationInterest>();
}
