using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACWebsite.Models
{
    public partial class Event
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? RoomId { get; set; }
        public int? MenuItemId { get; set; }
        public int? GroupSize { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? EventCost { get; set; }
        public string EventNotes { get; set; }

        public virtual Room Room { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}
