using System;
using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class RubricRowHeaderDTO
    {
        [Range(1, int.MaxValue)]
        public int RubricRowHeaderId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricRowHeaderParentId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<RubricRowHeaderDTO> InverseRubricRowHeaderParent { get; set; } 
        public RubricRowHeaderDTO RubricRowHeaderParent { get; set; } 
        public ICollection<RubricRubricColumnDTO> RubricRubricColumns { get; set; } 
        public ICollection<RubricRubricRowHeaderDTO> RubricRubricRowHeaders { get; set; } 
    }
}
