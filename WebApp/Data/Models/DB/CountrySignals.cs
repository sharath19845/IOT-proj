using System;
using System.Collections.Generic;

namespace Data.Models.DB
{
    public partial class CountrySignals
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public int? SignalStrength { get; set; }
    }
}
