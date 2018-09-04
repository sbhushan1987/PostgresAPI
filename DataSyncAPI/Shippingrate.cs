using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Shippingrate
    {
        public int Id { get; set; }
        public int Providerid { get; set; }
        public int Regionid { get; set; }
        public string Detail { get; set; }
        public decimal? Rate { get; set; }
    }
}
