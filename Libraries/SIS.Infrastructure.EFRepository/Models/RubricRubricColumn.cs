using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RubricRubricColumn
{
    public int RubricRubricColumnId { get; set; }

    public int RubricId { get; set; }

    public int RubricColumnId { get; set; }

    public int RubricHeaderId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Rubric Rubric { get; set; } = null!;

    public virtual RubricColumn RubricColumn { get; set; } = null!;

    public virtual RubricRowHeader RubricHeader { get; set; } = null!;

    public virtual ICollection<RubricInstanceScore> RubricInstanceScores { get; set; } = new List<RubricInstanceScore>();
}
