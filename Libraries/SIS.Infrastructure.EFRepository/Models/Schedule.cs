using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime StopDate { get; set; }

    public int SchedulingTimeslotId { get; set; }

    public int CourseId { get; set; }

    public int CourseGroupId { get; set; }

    public int RoomId { get; set; }

    public int TeacherId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual CourseGroup CourseGroup { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual SchedulingTimeslot SchedulingTimeslot { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
