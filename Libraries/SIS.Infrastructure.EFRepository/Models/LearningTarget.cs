using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class LearningTarget
{
    public int LearningTargetId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int LearningOutcomeId { get; set; }

    public int ControlLevelId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ControlLevel ControlLevel { get; set; } = null!;

    public virtual LearningOutcome LearningOutcome { get; set; } = null!;
}
