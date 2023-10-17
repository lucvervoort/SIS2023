using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RubricRow
{
    public int RubricRowId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int MaxScore { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<RubricRubricRow> RubricRubricRows { get; set; } = new List<RubricRubricRow>();
}
