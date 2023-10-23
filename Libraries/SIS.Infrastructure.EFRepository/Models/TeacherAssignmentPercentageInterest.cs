using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class TeacherAssignmentPercentageInterest
{
    public int TeacherAssignmentPercentageInterestId { get; set; }

    public int AcademicYearId { get; set; }

    public int TeacherId { get; set; }

    public int PeriodId { get; set; }

    public int Percentage { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual AcademicYear AcademicYear { get; set; } = null!;

    public virtual Period Period { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
