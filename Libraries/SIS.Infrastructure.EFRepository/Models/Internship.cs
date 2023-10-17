using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Internship
{
    public int InternshipId { get; set; }

    public int EducationId { get; set; }

    public int CompanyId { get; set; }

    public string Description { get; set; } = null!;

    public int AddressId { get; set; }

    public int PositionCount { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Education Education { get; set; } = null!;
}
