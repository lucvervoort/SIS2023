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

    public bool IsDeleted { get; set; }

    public virtual ICollection<StudentIoem> StudentIoems { get; set; } = new List<StudentIoem>();

    public virtual ICollection<TeacherAssignmentPercentageInterest> TeacherAssignmentPercentageInterests { get; set; } = new List<TeacherAssignmentPercentageInterest>();

    public virtual ICollection<TeacherCoordinationRoleInterest> TeacherCoordinationRoleInterests { get; set; } = new List<TeacherCoordinationRoleInterest>();

    public virtual ICollection<TeacherCourseInterest> TeacherCourseInterests { get; set; } = new List<TeacherCourseInterest>();

    public virtual ICollection<TeacherInterest> TeacherInterests { get; set; } = new List<TeacherInterest>();

    public virtual ICollection<TeacherLocationInterest> TeacherLocationInterests { get; set; } = new List<TeacherLocationInterest>();
}
