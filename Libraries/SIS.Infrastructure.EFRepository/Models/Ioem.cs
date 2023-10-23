using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Ioem
{
    public int Ioemid { get; set; }

    public string ShortName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Title { get; set; }

    public string? Detail { get; set; }

    public string? Remark { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<StudentIoem> StudentIoems { get; set; } = new List<StudentIoem>();
}
