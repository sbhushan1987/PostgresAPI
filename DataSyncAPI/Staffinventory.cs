using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Staffinventory
    {
        public int Id { get; set; }
        public int? Issuedby { get; set; }
        public int? Productno { get; set; }
        public DateTime? Issuedate { get; set; }
        public DateTime? Returndate { get; set; }
        public int? Staffid { get; set; }
        public int? Quantity { get; set; }
        public string Detail { get; set; }
        public bool? Returned { get; set; }
    }
}
