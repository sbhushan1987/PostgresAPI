using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Ztransactions
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string Tdate { get; set; }
        public float? NonVatTotal { get; set; }
        public float? VatAmount { get; set; }
        public float? TotalAmount { get; set; }
        public float? Balance { get; set; }
        public int? StaffId { get; set; }
        public int? CustId { get; set; }
    }
}
