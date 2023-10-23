using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class InternshipContact
{
    public int InternshipId { get; set; }

    public int ContactId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Contact Contact { get; set; } = null!;

    public virtual Internship Internship { get; set; } = null!;
}
