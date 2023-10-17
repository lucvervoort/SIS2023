using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class StudentGroup
{
    public int StudentGroupId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CourseGroupStudentGroup> CourseGroupStudentGroups { get; set; } = new List<CourseGroupStudentGroup>();

    public virtual ICollection<StudentStudentGroup> StudentStudentGroups { get; set; } = new List<StudentStudentGroup>();
}
