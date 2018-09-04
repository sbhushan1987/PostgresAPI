using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Invoicedetail
    {
        public int Id { get; set; }
        public string Invoiceid { get; set; }
        public int? Productid { get; set; }
        public string Barcode { get; set; }
        public decimal? Saleprice { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal Tax { get; set; }
        public int? Staffid { get; set; }
        public DateTime? Invoicedate { get; set; }
        public int? Branchid { get; set; }
    }
}
