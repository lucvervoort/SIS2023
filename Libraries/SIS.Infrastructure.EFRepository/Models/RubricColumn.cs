using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RubricColumn
{
    public int RubricColumnId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<RubricRubricColumn> RubricRubricColumns { get; set; } = new List<RubricRubricColumn>();
}
