using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class CourseGroupStudent
{
    public int CourseGroupStudentId { get; set; }

    public int CourseGroupId { get; set; }

    public int StudentId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual CourseGroup CourseGroup { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
