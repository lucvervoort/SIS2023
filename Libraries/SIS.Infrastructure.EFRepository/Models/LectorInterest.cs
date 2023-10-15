using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class LectorInterest
{
    public int LectorInterestId { get; set; }

    public int AcademicYearId { get; set; }

    public int LectorId { get; set; }

    public string? Description { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual AcademicYear AcademicYear { get; set; } = null!;

    public virtual Lector Lector { get; set; } = null!;
}
