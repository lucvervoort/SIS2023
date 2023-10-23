using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class StudentStudentGroup
{
    public int StudentStudentGroupId { get; set; }

    public int StudentGroupId { get; set; }

    public int StudentId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual StudentGroup StudentGroup { get; set; } = null!;
}
