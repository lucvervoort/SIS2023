using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RubricInstance
{
    public int RubricInstanceId { get; set; }

    public int AuthorPersonId { get; set; }

    public int RubricId { get; set; }

    public int ScorePersonId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Person AuthorPerson { get; set; } = null!;

    public virtual Rubric Rubric { get; set; } = null!;

    public virtual ICollection<RubricInstanceScore> RubricInstanceScores { get; set; } = new List<RubricInstanceScore>();

    public virtual Person ScorePerson { get; set; } = null!;
}
