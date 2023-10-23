using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class TeacherGroup
{
    public int TeacherGroupId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CourseGroupTeacherGroup> CourseGroupTeacherGroups { get; set; } = new List<CourseGroupTeacherGroup>();

    public virtual ICollection<TeacherTeacherGroup> TeacherTeacherGroups { get; set; } = new List<TeacherTeacherGroup>();
}
