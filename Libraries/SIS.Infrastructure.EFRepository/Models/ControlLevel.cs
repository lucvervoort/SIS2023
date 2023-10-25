using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class ControlLevel
{
    public int ControlLevelId { get; set; }

    public string Name { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual ICollection<LearningTarget> LearningTargets { get; set; } = new List<LearningTarget>();
}
