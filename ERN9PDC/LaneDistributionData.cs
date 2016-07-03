using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERN9PDC
{
    public class LaneDistributionData
    {
        public string Location { get; set; }
        public uint Lanes { get; set; }
        public uint DistributionFactor { get; set; }
    }
}