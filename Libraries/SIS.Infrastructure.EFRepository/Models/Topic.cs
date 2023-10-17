using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Topic
{
    public int TopicId { get; set; }

    public int TopicCategoryId { get; set; }

    public string Description { get; set; } = null!;

    public int Priority { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TopicCategory TopicCategory { get; set; } = null!;
}
