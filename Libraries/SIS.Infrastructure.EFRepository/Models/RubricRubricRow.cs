using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RubricRubricRow
{
    public int RubricRubricRowId { get; set; }

    public int RubricId { get; set; }

    public int RubricRowId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Rubric Rubric { get; set; } = null!;

    public virtual RubricRow RubricRow { get; set; } = null!;
}
