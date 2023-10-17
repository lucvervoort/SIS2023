using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string Abbreviation { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public int AssignmentPercentage { get; set; }

    public int TeacherTypeId { get; set; }

    public int RegistrationStateId { get; set; }

    public int PersonId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CourseGroupTeacher> CourseGroupTeachers { get; set; } = new List<CourseGroupTeacher>();

    public virtual Person Person { get; set; } = null!;

    public virtual RegistrationState RegistrationState { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<TeacherAssignmentPercentageInterest> TeacherAssignmentPercentageInterests { get; set; } = new List<TeacherAssignmentPercentageInterest>();

    public virtual ICollection<TeacherCoordinationRoleInterest> TeacherCoordinationRoleInterests { get; set; } = new List<TeacherCoordinationRoleInterest>();

    public virtual ICollection<TeacherCourseInterest> TeacherCourseInterests { get; set; } = new List<TeacherCourseInterest>();

    public virtual ICollection<TeacherInterest> TeacherInterests { get; set; } = new List<TeacherInterest>();

    public virtual ICollection<TeacherLocationInterest> TeacherLocationInterests { get; set; } = new List<TeacherLocationInterest>();

    public virtual ICollection<TeacherTeacherGroup> TeacherTeacherGroups { get; set; } = new List<TeacherTeacherGroup>();

    public virtual TeacherType TeacherType { get; set; } = null!;
}
