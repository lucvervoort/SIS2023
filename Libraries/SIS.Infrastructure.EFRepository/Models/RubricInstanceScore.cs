using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RubricInstanceScore
{
    public int RubricInstanceScoreId { get; set; }

    public int RubricInstanceId { get; set; }

    public int RubricRubricRowId { get; set; }

    public int RubricRubricColumnId { get; set; }

    public decimal Score { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual RubricInstance RubricInstance { get; set; } = null!;

    public virtual RubricRubricColumn RubricRubricColumn { get; set; } = null!;

    public virtual RubricRubricRow RubricRubricRow { get; set; } = null!;
}
