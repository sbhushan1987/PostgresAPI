using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Cart
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int Productno { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public int? Orderid { get; set; }
    }
}
