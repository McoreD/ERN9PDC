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

        public static AxleEquivalencyFactorData1 F_AxleEquivalencyFactors { get; private set; }

        private static double[,] cF = new double[10, 2]; // 10 pairs array

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

        public static void SetAxleEquivalencyFactors(AxleEquivalencyFactorData1 f)
        {
            F_AxleEquivalencyFactors = f;
        }

        public static void SetAxleEquivalencyFactor(string txt)
        {
            F_AxleEquivalencyFactor = TryParseDouble(txt);
        }

        public static void SetAxleEquivalencyFactors(int classValue, string c, string F)
        {
            if (classValue > 2)
            {
                cF[classValue - 3, 0] = TryParseDouble(c);
                cF[classValue - 3, 1] = TryParseDouble(F);
            }
        }

        public static double SetHeavyVehiclePercentage()
        {
            double perc = 0.0;

            for (int i = 0; i < 10; i++)
            {
                perc += cF[i, 0];
            }

            return perc;
        }

        public static double GetAECperHV()
        {
            return GetCF() / SetHeavyVehiclePercentage();
        }

        public static void SetHeavyVehiclePercentage(string txt)
        {
            double r = TryParseDouble(txt);
            if (r >= 1) r = r / 100.0;
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

        private static double GetCF()
        {
            double cF = 0.0;

            for (int i = 0; i < 10; i++)
            {
                cF += CalcHelper.cF[i, 0] * CalcHelper.cF[i, 1];
            }

            return cF;
        }

        public static double GetESA()
        {
            if (TrafficMethod == TrafficMethod.TrafficMethod2)
                return ESA_DesignTraffic = 365 * n_AADT * d_LaneDistributionFactor * R_CumulativeGrowthFactor * c_HeavyVehiclesPerc * F_AxleEquivalencyFactor / 10000.0;
            else
            {
                return ESA_DesignTraffic = 365 * n_AADT * d_LaneDistributionFactor * R_CumulativeGrowthFactor * GetCF() / 10000.0;
            }
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