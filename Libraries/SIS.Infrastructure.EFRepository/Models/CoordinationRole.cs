using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class CoordinationRole
{
    public int CoordinationRoleId { get; set; }

    public string Name { get; set; } = null!;

    public int AssignmentPercentage { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TeacherCoordinationRoleInterest> TeacherCoordinationRoleInterests { get; set; } = new List<TeacherCoordinationRoleInterest>();
}
