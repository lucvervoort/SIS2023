using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class TeacherDTO
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
