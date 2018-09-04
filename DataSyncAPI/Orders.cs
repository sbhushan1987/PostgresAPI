using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Orders
    {
        public int Id { get; set; }
        public DateTime Datein { get; set; }
        public int? Customerid { get; set; }
        public int? Staffid { get; set; }
        public bool? Paid { get; set; }
        public decimal Ordertotal { get; set; }
        public int? Branchid { get; set; }
        public string Ordertype { get; set; }
        public string Detail { get; set; }
        public decimal? Delivery { get; set; }
        public bool? Voided { get; set; }
    }
}
