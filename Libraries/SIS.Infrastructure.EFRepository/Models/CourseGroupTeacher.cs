using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class CourseGroupTeacher
{
    public int CourseGroupTeacherId { get; set; }

    public int CourseGroupId { get; set; }

    public int TeacherId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual CourseGroup CourseGroup { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
