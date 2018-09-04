using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Orderdetail
    {
        public int Id { get; set; }
        public int Orderid { get; set; }
        public int Productno { get; set; }
        public int Quantity { get; set; }

        public Product ProductnoNavigation { get; set; }
    }
}
