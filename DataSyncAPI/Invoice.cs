using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string Invoiceid { get; set; }
        public bool? Isquotation { get; set; }
        public int? Customerid { get; set; }
        public string Detail { get; set; }
        public string Proposaldetail { get; set; }
        public DateTime? Duedate { get; set; }
        public DateTime? Invoicedate { get; set; }
        public string Status { get; set; }
        public decimal? Tax { get; set; }
        public int? Staffid { get; set; }
        public int? Branchid { get; set; }
        public decimal? Netamount { get; set; }
        public decimal? Taxamount { get; set; }
        public decimal? Total { get; set; }
    }
}
