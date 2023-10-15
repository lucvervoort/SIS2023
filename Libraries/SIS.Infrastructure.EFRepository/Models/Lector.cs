using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Lector
{
    public int LectorId { get; set; }

    public string Abbreviation { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public int AssignmentPercentage { get; set; }

    public int LectorTypeId { get; set; }

    public int RegistrationStateId { get; set; }

    public int PersonId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual ICollection<CourseGroupLector> CourseGroupLectors { get; set; } = new List<CourseGroupLector>();

    public virtual ICollection<LectorAssignmentPercentageInterest> LectorAssignmentPercentageInterests { get; set; } = new List<LectorAssignmentPercentageInterest>();

    public virtual ICollection<LectorCoordinationRoleInterest> LectorCoordinationRoleInterests { get; set; } = new List<LectorCoordinationRoleInterest>();

    public virtual ICollection<LectorCourseInterest> LectorCourseInterests { get; set; } = new List<LectorCourseInterest>();

    public virtual ICollection<LectorInterest> LectorInterests { get; set; } = new List<LectorInterest>();

    public virtual ICollection<LectorLectorGroup> LectorLectorGroups { get; set; } = new List<LectorLectorGroup>();

    public virtual ICollection<LectorLocationInterest> LectorLocationInterests { get; set; } = new List<LectorLocationInterest>();

    public virtual LectorType LectorType { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual RegistrationState RegistrationState { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
