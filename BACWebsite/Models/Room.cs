using System;
using System.Collections.Generic;

namespace BACWebsite.Models
{
    public partial class Room
    {
        public Room()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int? Depth { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
