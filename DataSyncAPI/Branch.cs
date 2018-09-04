using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Branch
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
