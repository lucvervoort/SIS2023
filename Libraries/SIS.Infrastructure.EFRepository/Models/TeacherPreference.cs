using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class TeacherPreference
{
    public int TeacherPreferenceId { get; set; }

    public int Preference { get; set; }

    public string? Description { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TeacherCoordinationRoleInterest> TeacherCoordinationRoleInterests { get; set; } = new List<TeacherCoordinationRoleInterest>();

    public virtual ICollection<TeacherCourseInterest> TeacherCourseInterests { get; set; } = new List<TeacherCourseInterest>();

    public virtual ICollection<TeacherLocationInterest> TeacherLocationInterests { get; set; } = new List<TeacherLocationInterest>();
}
