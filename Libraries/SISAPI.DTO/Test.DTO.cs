using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class TestDTO
    {
        [Range(1, int.MaxValue)]
        public int TestId { get; set; }

        [Range(1, int.MaxValue)]
        public int OfficialCode { get; set; }

        [Range(1, int.MaxValue)]
        public int CourseId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<ScoreDTO> Scores { get; set; } 
    }
}