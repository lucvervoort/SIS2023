using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Info
{
    public int InfoId { get; set; }

    public int ConceptId { get; set; }

    public int RefKeyId { get; set; }

    public int InfoTypeId { get; set; }

    public string? Data { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Concept Concept { get; set; } = null!;

    public virtual InfoType InfoType { get; set; } = null!;
}
