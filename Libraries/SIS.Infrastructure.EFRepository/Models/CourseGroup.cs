using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class CourseGroup
{
    public int CourseGroupId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual ICollection<CourseGroupLectorGroup> CourseGroupLectorGroups { get; set; } = new List<CourseGroupLectorGroup>();

    public virtual ICollection<CourseGroupLector> CourseGroupLectors { get; set; } = new List<CourseGroupLector>();

    public virtual ICollection<CourseGroupStudentGroup> CourseGroupStudentGroups { get; set; } = new List<CourseGroupStudentGroup>();

    public virtual ICollection<CourseGroupStudent> CourseGroupStudents { get; set; } = new List<CourseGroupStudent>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
