using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? Transactionid { get; set; }
        public string Detail { get; set; }
        public decimal? Amountdue { get; set; }
        public string Phone { get; set; }
        public string Refcode { get; set; }
        public decimal? Changegiven { get; set; }
        public int? Customerid { get; set; }
        public DateTime? Datein { get; set; }
        public int? Staffid { get; set; }
        public decimal? Amountpaid { get; set; }
        public int? Orderid { get; set; }
        public string Paymenttype { get; set; }
    }
}
