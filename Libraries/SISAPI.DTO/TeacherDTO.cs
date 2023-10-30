using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class TeacherDTO
    {
        [MinLength(2),MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")] // OK for swagger input, not ok for Newtonsoft deserialization
        public DateTime BirthDate { get; set; } = DateTime.Now; // additionele properties zijn mogelijk
    }
}
