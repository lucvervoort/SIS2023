using System;
using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class RubricRubricColumnDTO
    {
        [Range(1, int.MaxValue)]
        public int RubricRubricColumnId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricColumnId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricHeaderId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

        public RubricDTO Rubric { get; set; } 
        public RubricColumnDTO RubricColumn { get; set; } 
        public RubricRowHeaderDTO RubricHeader { get; set; } 
        public ICollection<RubricInstanceScoreDTO> RubricInstanceScores { get; set; } 
    }
}
