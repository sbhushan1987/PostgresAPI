using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Diningtable
    {
        public int Id { get; set; }
        public int? Branchid { get; set; }
        public string Tablename { get; set; }
        public string Description { get; set; }
        public int? Capacity { get; set; }
    }
}
