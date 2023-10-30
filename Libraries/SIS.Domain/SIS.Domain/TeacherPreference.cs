using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain
{
    public class TeacherPreference
    {
        public int TeacherPreferenceId { get; set; }
        public int Preference { get; set; }
        public string Description { get; set; }
    }
}
