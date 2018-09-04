using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Inventorydetail
    {
        public int Id { get; set; }
        public string Inventoryid { get; set; }
        public int? Productno { get; set; }
        public double? Quantity { get; set; }
        public DateTime? Datein { get; set; }
        public double? Buyprice { get; set; }
        public double? Initial { get; set; }
        public double? Balance { get; set; }
        public string Batchno { get; set; }
        public string Mode { get; set; }
        public int? Staffid { get; set; }
        public int? Customerid { get; set; }
        public string Detail { get; set; }
        public double? Saleprice { get; set; }
        public string Pono { get; set; }
        public int? Branchid { get; set; }
        public int? Unitid { get; set; }
        public decimal? Tax1 { get; set; }
        public decimal? Tax2 { get; set; }
        public decimal? Tax3 { get; set; }
        public decimal? Taxamount { get; set; }
        public decimal? Netamount { get; set; }
        public decimal? Total { get; set; }
        public int Supplierid { get; set; }
        public int? Purchaseid { get; set; }
        public int Issuedstaffid { get; set; }
    }
}
