using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class PresenceDTO
    {
        [Range(1, int.MaxValue)]
        public int PresenceId { get; set; }

        [Range(1, int.MaxValue)]
        public int OfficialCode { get; set; }

        [Required]
        public string Qrcode { get; set; }

        [Range(1, int.MaxValue)]
        public int PresenceStateId { get; set; }

        [Range(1, int.MaxValue)]
        public int PersonId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

        public PersonDTO Person { get; set; } 
        public PresenceStateDTO PresenceState { get; set; } 
    }
}
