using System;
using System.Collections.Generic;

namespace DataSyncAPI
{
    public partial class Unit
    {
        public Unit()
        {
            Unitrelation = new HashSet<Unitrelation>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }

        public ICollection<Unitrelation> Unitrelation { get; set; }
    }
}
