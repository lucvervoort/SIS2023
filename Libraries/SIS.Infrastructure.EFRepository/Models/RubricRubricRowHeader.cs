using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RubricRubricRowHeader
{
    public int RubricRubricRowHeaderId { get; set; }

    public int RubricId { get; set; }

    public int RubricRowHeaderId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Rubric Rubric { get; set; } = null!;

    public virtual RubricRowHeader RubricRowHeader { get; set; } = null!;
}
