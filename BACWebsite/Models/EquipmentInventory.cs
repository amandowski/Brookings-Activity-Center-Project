using System;
using System.Collections.Generic;

namespace BACWebsite.Models
{
    public partial class EquipmentInventory
    {
        public int Id { get; set; }
        public string ItemTitle { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public bool CheckedOut { get; set; }
        public decimal Cost { get; set; }
    }
}
