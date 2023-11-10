using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class ScoreDTO
    {
        [Range(1, int.MaxValue)]
        public int ScoreId { get; set; }

        [Range(0, 100)]
        public decimal? TotalPercentage { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Total { get; set; }

        [Range(1, int.MaxValue)]
        public int TestId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

       
    }
}
