using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class LearningOutcome
{
    public int LearningOutcomeId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int LearningOutcomeTypeId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual LearningOutcomeType LearningOutcomeType { get; set; } = null!;

    public virtual ICollection<LearningTarget> LearningTargets { get; set; } = new List<LearningTarget>();
}
