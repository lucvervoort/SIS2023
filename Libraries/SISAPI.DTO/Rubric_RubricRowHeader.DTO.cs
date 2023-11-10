using System;
using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class RubricRubricRowHeaderDTO
    {
        [Range(1, int.MaxValue)]
        public int RubricRubricRowHeaderId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricRowHeaderId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

        public RubricDTO Rubric { get; set; } 
        public RubricRowHeaderDTO RubricRowHeader { get; set; } 
    }
}
