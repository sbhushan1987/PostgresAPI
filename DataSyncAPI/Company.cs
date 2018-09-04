using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Company
    {
        public int Id { get; set; }
        public string Companyname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Tinnumber { get; set; }
        public string Defaultcurrency { get; set; }
        public int? Cash { get; set; }
        public int? Card { get; set; }
        public int? Cheque { get; set; }
        public int? Firstinvoice { get; set; }
        public string Logo { get; set; }
        public string Showtax { get; set; }
        public string Receiptmessage { get; set; }
        public string Invoicemessage { get; set; }
        public string Taxmessage { get; set; }
        public string Phone { get; set; }
        public bool? Tax1 { get; set; }
        public bool? Tax2 { get; set; }
        public bool? Tax3 { get; set; }
    }
}
