using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class TeacherTeacherGroup
{
    public int TeacherTeacherGroupId { get; set; }

    public int TeacherGroupId { get; set; }

    public int TeacherId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual TeacherGroup TeacherGroup { get; set; } = null!;
}
