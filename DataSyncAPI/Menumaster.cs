using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Menumaster
    {
        public int Id { get; set; }
        public string Menuid { get; set; }
        public string Menuname { get; set; }
        public string ParentMenuid { get; set; }
        public string UserRoll { get; set; }
        public string Ikon { get; set; }
        public string Menuurl { get; set; }
        public char? UseYn { get; set; }
        public DateTime? Createddate { get; set; }
        public int? Ordering { get; set; }
    }
}
