using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class TeacherCourseInterest
{
    public int TeacherCourseInterestId { get; set; }

    public int AcademicYearId { get; set; }

    public int TeacherId { get; set; }

    public int TeacherPreferenceId { get; set; }

    public int CourseId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual AcademicYear AcademicYear { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual TeacherPreference TeacherPreference { get; set; } = null!;
}
