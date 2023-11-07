using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain
{
    public class Room
    {
        public int RoomId { get; set; }
        public int BuildingId { get; set; }
        public string? Name { get; set; }
        public int? RoomTypeId { get; set; }
        public int? RoomKindId { get; set; }
        public int? Capacity { get; set; }
    }
}
