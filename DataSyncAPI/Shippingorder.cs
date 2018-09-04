using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Shippingorder
    {
        public int Id { get; set; }
        public int Orderid { get; set; }
        public int Providerid { get; set; }
        public decimal Rate { get; set; }
        public int? Transactionid { get; set; }
        public int Regionid { get; set; }
        public int Customerid { get; set; }
    }
}
