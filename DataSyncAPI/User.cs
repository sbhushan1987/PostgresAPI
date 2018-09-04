using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? ReceiveStock { get; set; }
        public int? PreviewReceipt { get; set; }
        public int? Branchcode { get; set; }
        public string ApplicationName { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool? IsApproved { get; set; }
        public int? Branchid { get; set; }
        public int? AccessFailedCount { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool? PhoneConfirmed { get; set; }
        public string Pin { get; set; }
        public string Hired { get; set; }
        public bool? Wholesale { get; set; }
        public bool? Retail { get; set; }
    }
}
