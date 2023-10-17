using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RubricRowHeader
{
    public int RubricRowHeaderId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int RubricRowHeaderParentId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<RubricRowHeader> InverseRubricRowHeaderParent { get; set; } = new List<RubricRowHeader>();

    public virtual RubricRowHeader RubricRowHeaderParent { get; set; } = null!;

    public virtual ICollection<RubricRubricColumn> RubricRubricColumns { get; set; } = new List<RubricRubricColumn>();

    public virtual ICollection<RubricRubricRowHeader> RubricRubricRowHeaders { get; set; } = new List<RubricRubricRowHeader>();
}
