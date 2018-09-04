using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Commission
    {
        public int Id { get; set; }
        public string Ordertype { get; set; }
        public string Calculation { get; set; }
        public decimal? Rate { get; set; }
    }
}
