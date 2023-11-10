using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class PeriodDTO
    {
        [Range(1, int.MaxValue)]
        public int PeriodId { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }
    }
}