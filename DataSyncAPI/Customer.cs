using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Customername { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? Creditlimit { get; set; }
        public int? Points { get; set; }
        public string Address { get; set; }
        public int? Regionid { get; set; }
    }
}
