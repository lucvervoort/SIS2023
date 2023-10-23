using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public int CampusId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

    public virtual Campus Campus { get; set; } = null!;

    public virtual ICollection<TeacherLocationInterest> TeacherLocationInterests { get; set; } = new List<TeacherLocationInterest>();
}
