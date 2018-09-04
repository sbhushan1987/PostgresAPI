using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Purchaseorderdetail
    {
        public int PurchaseOrderDetailId { get; set; }
        public int? Pono { get; set; }
        public string ProductNo { get; set; }
        public int Qty { get; set; }
        public int? BuyingPrice { get; set; }
        public int? ItemPrice { get; set; }
        public int? Discount { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}
