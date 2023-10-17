using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public long OfficialCode { get; set; }

    public int RegistrationStateId { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public int PersonId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<CourseGroupStudent> CourseGroupStudents { get; set; } = new List<CourseGroupStudent>();

    public virtual Person Person { get; set; } = null!;

    public virtual RegistrationState RegistrationState { get; set; } = null!;

    public virtual ICollection<StudentIoem> StudentIoems { get; set; } = new List<StudentIoem>();

    public virtual ICollection<StudentStudentGroup> StudentStudentGroups { get; set; } = new List<StudentStudentGroup>();
}
