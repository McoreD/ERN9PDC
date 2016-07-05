using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERN9PDC
{
    public static class CalcHelper
    {
        public static TrafficMethod TrafficMethod { get; set; } = TrafficMethod.TrafficMethod2;

        public static uint CBR_Subgrade { get; private set; } = 12;
        public static uint CBR_Basecourse { get; private set; } = 30;
        public static uint n_AADT { get; private set; } = 1000;
        public static double c_HeavyVehiclesPerc { get; private set; } = 6.8;
        public static double r_HeavyTrafficGrowtRate { get; private set; } = 0.03;
        public static uint d_LaneDistributionFactor { get; private set; } = 100;
        public static double F_AxleEquivalencyFactor { get; private set; }
        public static uint P_PavementDesignLife { get; private set; } = 40;
        public static double R_CumulativeGrowthFactor { get; private set; }
        public static double ESA_DesignTraffic { get; private set; }

        public static AxleEquivalencyFactorData2 F_AxleEquivalencyFactors { get; private set; }

        private static uint TryParseUint(string txt)
        {
            uint n = 0;
            uint.TryParse(txt, out n);
            return n;
        }

        private static double TryParseDouble(string txt)
        {
            double n = 0;
            double.TryParse(txt, out n);
            return n;
        }

        public static void SetCbrSubgrade(uint cbr)
        {
            CBR_Subgrade = cbr;
        }

        public static void SetAADT(string txt)
        {
            n_AADT = TryParseUint(txt);
        }

        public static void SetLaneDistributionFactor(uint d)
        {
            d_LaneDistributionFactor = d;
        }

        public static void SetAxleEquivalencyFactor(double F)
        {
            F_AxleEquivalencyFactor = F;
        }

        public static void SetAxleEquivalencyFactor(string txt)
        {
            F_AxleEquivalencyFactor = TryParseDouble(txt);
        }

        public static void SetHeavyVehiclePercentage(string txt)
        {
            double r = TryParseDouble(txt);
            if (r > 1) r = r / 100.0;
            r_HeavyTrafficGrowtRate = r;
        }

        public static void SetPavmentDesignLife(string txt)
        {
            P_PavementDesignLife = TryParseUint(txt);
        }

        public static void SetESA(string txt)
        {
            ESA_DesignTraffic = TryParseDouble(txt);
        }

        public static double GetR()
        {
            return R_CumulativeGrowthFactor = r_HeavyTrafficGrowtRate > 0 ? (Math.Pow(1 + r_HeavyTrafficGrowtRate, P_PavementDesignLife) - 1) / r_HeavyTrafficGrowtRate : 0;
        }

        public static double GetESA()
        {
            return ESA_DesignTraffic = n_AADT * F_AxleEquivalencyFactor * (d_LaneDistributionFactor / 100.0) * (c_HeavyVehiclesPerc / 100.0) * R_CumulativeGrowthFactor * 365;
        }

        public static double GetThickness(uint cbr)
        {
            return (219.0 - 211.0 * Math.Log10(cbr) + 58.0 * Math.Pow(Math.Log10(cbr), 2)) * Math.Log10(ESA_DesignTraffic / 120.0);
        }

        public static double GetThicknessGranuar()
        {
            return GetThickness(CBR_Subgrade);
        }

        public static double GetThicknessGranuarRounded()
        {
            return Math.Ceiling(GetThickness(CBR_Subgrade) / 5.0) * 5;
        }

        public static double GetThicknessBasecourse()
        {
            return GetThickness(CBR_Basecourse);
        }

        public static double GetThicknessBasecourseRounded()
        {
            return Math.Ceiling(GetThickness(CBR_Basecourse) / 5.0) * 5;
        }
    }
}