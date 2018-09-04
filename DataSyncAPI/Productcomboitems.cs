using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Productcomboitems
    {
        public int Id { get; set; }
        public int Combono { get; set; }
        public int Productno { get; set; }
        public double? Quantity { get; set; }
        public int? Unit { get; set; }

        public Product ProductnoNavigation { get; set; }
    }
}
