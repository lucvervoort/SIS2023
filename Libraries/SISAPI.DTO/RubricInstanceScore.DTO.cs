using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class RubricInstanceScoreDTO
    {
        [Range(1, int.MaxValue)]
        public int RubricInstanceScoreId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricInstanceId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricRubricRowId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricRubricColumnId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Score { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

        public RubricInstanceDTO RubricInstance { get; set; } 
        public RubricRubricColumnDTO RubricRubricColumn { get; set; } 
        public RubricRubricRowDTO RubricRubricRow { get; set; } 
}
}