using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Score
{
    public int ScoreId { get; set; }

    public decimal? TotalPercentage { get; set; }

    public decimal? Total { get; set; }

    public int TestId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Test Test { get; set; } = null!;
}
