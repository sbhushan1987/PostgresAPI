using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Unitrelation
    {
        public int Id { get; set; }
        public int Baseunit { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public decimal? Conversionfactor { get; set; }
        public decimal? Multiplier { get; set; }

        public Unit BaseunitNavigation { get; set; }
    }
}
