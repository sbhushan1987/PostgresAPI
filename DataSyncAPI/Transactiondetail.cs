using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Transactiondetail
    {
        public int Id { get; set; }
        public int? Transactionid { get; set; }
        public string Invoiceno { get; set; }
        public int? Productno { get; set; }
        public string Barcode { get; set; }
        public decimal? Saleprice { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal Tax1 { get; set; }
        public decimal Tax2 { get; set; }
        public decimal Tax3 { get; set; }
        public int? Staffid { get; set; }
        public decimal Buyprice { get; set; }
        public DateTime? Datein { get; set; }
        public int? Branchid { get; set; }
    }
}
