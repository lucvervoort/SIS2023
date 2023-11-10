using System;
using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class RubricRubricRowDTO
    {
        [Range(1, int.MaxValue)]
        public int RubricRubricRowId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricRowId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

        public RubricDTO Rubric { get; set; } 
        public ICollection<RubricInstanceScoreDTO> RubricInstanceScores { get; set; } 
        public RubricRowDTO RubricRow { get; set; } 
    }
}
