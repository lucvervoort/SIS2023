using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class StudentIoem
{
    public int StudentIoemid { get; set; }

    public int AcademicYearId { get; set; }

    public int StudentId { get; set; }

    public int Ioemid { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual AcademicYear AcademicYear { get; set; } = null!;

    public virtual Ioem Ioem { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
