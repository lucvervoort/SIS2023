using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public int LetterId { get; set; }

    public string Name { get; set; } = null!;

    public int CourseTypeId { get; set; }

    public int Points { get; set; }

    public string Weight { get; set; } = null!;

    public int HoursTotal { get; set; }

    public int HoursContact { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CourseTrajectory> CourseTrajectories { get; set; } = new List<CourseTrajectory>();

    public virtual CourseType CourseType { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<TeacherCourseInterest> TeacherCourseInterests { get; set; } = new List<TeacherCourseInterest>();
}
