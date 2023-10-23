using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public int PersonId { get; set; }

    public int CompanyId { get; set; }

    public DateTime Verified { get; set; }

    public string FunctionRole { get; set; } = null!;

    public string Department { get; set; } = null!;

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
