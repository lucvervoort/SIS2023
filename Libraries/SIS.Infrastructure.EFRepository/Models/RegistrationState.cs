using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RegistrationState
{
    public int RegistrationStateId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual ICollection<Lector> Lectors { get; set; } = new List<Lector>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
