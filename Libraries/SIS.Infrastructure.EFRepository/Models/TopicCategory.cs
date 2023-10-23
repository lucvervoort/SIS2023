using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class TopicCategory
{
    public int TopicCategoryId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
