using System;
using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class PresenceStateDTO
    {
        [Range(1, int.MaxValue)]
        public int PresenceStateId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<PresenceDTO> Presences { get; set; } 
    }
}
