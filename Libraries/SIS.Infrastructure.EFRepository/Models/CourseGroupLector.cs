using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class CourseGroupLector
{
    public int CourseGroupLectorId { get; set; }

    public int CourseGroupId { get; set; }

    public int LectorId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual CourseGroup CourseGroup { get; set; } = null!;

    public virtual Lector Lector { get; set; } = null!;
}
