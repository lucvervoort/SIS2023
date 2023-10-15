using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class AcademicYear
{
    public int AcademicYearId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime StopDate { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual ICollection<LectorAssignmentPercentageInterest> LectorAssignmentPercentageInterests { get; set; } = new List<LectorAssignmentPercentageInterest>();

    public virtual ICollection<LectorCoordinationRoleInterest> LectorCoordinationRoleInterests { get; set; } = new List<LectorCoordinationRoleInterest>();

    public virtual ICollection<LectorCourseInterest> LectorCourseInterests { get; set; } = new List<LectorCourseInterest>();

    public virtual ICollection<LectorInterest> LectorInterests { get; set; } = new List<LectorInterest>();

    public virtual ICollection<LectorLocationInterest> LectorLocationInterests { get; set; } = new List<LectorLocationInterest>();

    public virtual ICollection<StudentIoem> StudentIoems { get; set; } = new List<StudentIoem>();
}
