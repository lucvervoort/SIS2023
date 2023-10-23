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

    public bool IsDeleted { get; set; }

    public virtual ICollection<CourseGroupStudentGroup> CourseGroupStudentGroups { get; set; } = new List<CourseGroupStudentGroup>();

    public virtual ICollection<CourseGroupStudent> CourseGroupStudents { get; set; } = new List<CourseGroupStudent>();

    public virtual ICollection<CourseGroupTeacherGroup> CourseGroupTeacherGroups { get; set; } = new List<CourseGroupTeacherGroup>();

    public virtual ICollection<CourseGroupTeacher> CourseGroupTeachers { get; set; } = new List<CourseGroupTeacher>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
