using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class LectorLectorGroup
{
    public int LectorLectorGroupId { get; set; }

    public int LectorGroupId { get; set; }

    public int LectorId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual Lector Lector { get; set; } = null!;

    public virtual LectorGroup LectorGroup { get; set; } = null!;
}
