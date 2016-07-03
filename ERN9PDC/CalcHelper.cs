using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERN9PDC
{
    public static class CalcHelper
    {
        public static uint CBR_Subgrade { get; private set; } = 12;
        public static uint CBR_Basecourse { get; private set; } = 30;
        public static uint n_AADT { get; private set; } = 30;
        public static double c_HeavyVehiclesPerc { get; private set; } = 6.8;
        public static double r_HeavyTrafficGrowtRate { get; private set; } = 0.03;
        public static uint d_LaneDistributionFactor { get; private set; } = 100;
        public static double F_AxleEquivalencyFactor { get; private set; }
        public static uint P_PavementDesignLife { get; private set; } = 40;
        public static double R_CumulativeGrowthFactor { get; private set; }
        public static double ESA_DesignTraffic { get; private set; }

        public static void SetLaneDistributionFactor(uint d)
        {
            d_LaneDistributionFactor = d;
        }

        public static void SetAxleEquivalencyFactor(double F)
        {
            F_AxleEquivalencyFactor = F;
        }

        public static void GetPavementThickness()
        {
            CalcR();
        }

        public static void CalcR()
        {
            R_CumulativeGrowthFactor = (Math.Pow(1 + r_HeavyTrafficGrowtRate, P_PavementDesignLife) - 1) / r_HeavyTrafficGrowtRate;
        }
    }
}