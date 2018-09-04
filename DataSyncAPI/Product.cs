using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Product
    {
        public Product()
        {
            Orderdetail = new HashSet<Orderdetail>();
            Productcomboitems = new HashSet<Productcomboitems>();
        }

        public int Productno { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal? Buyprice { get; set; }
        public decimal? Saleprice { get; set; }
        public int? Reorderlevel { get; set; }
        public int? Categoryno { get; set; }
        public int Expires { get; set; }
        public string Image { get; set; }
        public string Productcode { get; set; }
        public string Producttype { get; set; }
        public string Status { get; set; }
        public bool? Tax1 { get; set; }
        public bool? Tax2 { get; set; }
        public bool? Tax3 { get; set; }
        public int Unit { get; set; }
        public int Purchaseunit { get; set; }
        public int? Saleunit { get; set; }
        public decimal? Saleprice2 { get; set; }

        public ICollection<Orderdetail> Orderdetail { get; set; }
        public ICollection<Productcomboitems> Productcomboitems { get; set; }
    }
}
