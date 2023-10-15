using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class LectorCourseInterest
{
    public int LectorCourseInterestId { get; set; }

    public int AcademicYearId { get; set; }

    public int LectorId { get; set; }

    public int LectorPreferenceId { get; set; }

    public int CourseId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual AcademicYear AcademicYear { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual Lector Lector { get; set; } = null!;

    public virtual LectorPreference LectorPreference { get; set; } = null!;
}
