using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class CourseGroupLectorGroup
{
    public int CourseGroupLectorGroupId { get; set; }

    public int CourseGroupId { get; set; }

    public int LectorGroupId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual CourseGroup CourseGroup { get; set; } = null!;

    public virtual LectorGroup LectorGroup { get; set; } = null!;
}
