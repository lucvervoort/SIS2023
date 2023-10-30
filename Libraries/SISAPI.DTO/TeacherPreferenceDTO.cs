using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.API.DTO
{
    public class TeacherPreferenceDTO
    {
        public int TeacherPreferenceId { get; set; }
        public int Preference { get; set; }
        public string Description { get; set; }
    }
}
