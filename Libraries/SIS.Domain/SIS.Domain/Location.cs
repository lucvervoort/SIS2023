using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public int CampusId { get; set; }
    }
}
