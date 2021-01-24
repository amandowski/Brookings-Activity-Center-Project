using System;
using System.Collections.Generic;

namespace BACWebsite.Models
{
    public partial class Vendor
    {
        public int Id { get; set; }
        public string VendorName { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
    }
}
