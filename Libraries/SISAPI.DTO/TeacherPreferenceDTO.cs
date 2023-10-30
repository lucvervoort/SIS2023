using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class TeacherPreferenceDTO
    {
        public int TeacherPreferenceId { get; set; }
        [Range(1,10)]
        public int Preference { get; set; }
        public string Description { get; set; }
    }
}
