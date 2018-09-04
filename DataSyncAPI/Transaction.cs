using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string Invoiceno { get; set; }
        public decimal? Netamount { get; set; }
        public decimal? Taxamount { get; set; }
        public decimal? Total { get; set; }
        public decimal? Balance { get; set; }
        public int? Staffid { get; set; }
        public int? Customerid { get; set; }
        public decimal? Discount { get; set; }
        public string Detail { get; set; }
        public DateTime? Datein { get; set; }
        public int? Branchid { get; set; }
        public int? Orderid { get; set; }
        public string Transactiontype { get; set; }
        public decimal? Commission { get; set; }
        public decimal? Delivery { get; set; }
    }
}
