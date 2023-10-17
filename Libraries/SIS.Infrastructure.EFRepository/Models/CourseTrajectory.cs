using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class CourseTrajectory
{
    public int CourseTrajectoryId { get; set; }

    public int CourseId { get; set; }

    public int TrajectoryId { get; set; }

    public int StudyPoints { get; set; }

    public string? StudySheetUrl { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Trajectory Trajectory { get; set; } = null!;
}
