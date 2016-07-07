using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERN9PDC
{
    public static class CalcHelper
    {
        public static Settings Settings { get; private set; } = new Settings();

        #region Helper methods

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

        #endregion Helper methods

        public static void SetPavementDesignLife(string txt)
        {
            Settings.P_PavementDesignLife = TryParseUint(txt);
        }

        public static void SetCbrSubgrade(uint cbr)
        {
            Settings.CBR_Subgrade = cbr;
        }

        public static void SetAADT(string txt)
        {
            Settings.n_AADT = TryParseUint(txt);
        }

        #region r1 and r2

        public static double GetHVGrowthRate_r1()
        {
            double perc = 0.0;

            for (int i = 0; i < 10; i++)
            {
                perc += Settings.TrafficData[i, 0];
            }

            return perc;
        }

        public static void SetHVGrowthRate_r1(string txt)
        {
            double r = TryParseDouble(txt);
            if (r >= 1) r = r / 100.0;
            Settings.r1_HVGrowthRate = r;
        }

        public static void SetHVGrowthRate_r2(string txt)
        {
            double r = TryParseDouble(txt);
            if (r >= 1) r = r / 100.0;
            Settings.r2_HVGrowthRate = r;
        }

        #endregion r1 and r2

        public static void SetLaneDistributionFactor(uint d)
        {
            Settings.d_LaneDistributionFactor = d;
        }

        public static void SetHVPerc(string txt)
        {
            Settings.c_HVPerc = TryParseDouble(txt);
        }

        #region F and F3 to F12

        public static void SetAxleEquivalencyFactor(double F)
        {
            Settings.F_AxleEquivalencyFactor = F;
        }

        public static void SetAxleEquivalencyFactor(string txt)
        {
            Settings.F_AxleEquivalencyFactor = TryParseDouble(txt);
        }

        public static void SetFbyVehicleClass(int classValue, double F)
        {
            if (classValue > 2)
            {
                Settings.TrafficData[classValue - 3, 1] = F;
            }
        }

        public static double GetFbyVehicleClass(int classValue)
        {
            if (classValue > 2)
            {
                return Settings.TrafficData[classValue - 3, 1];
            }

            return 0;
        }

        #endregion F and F3 to F12

        #region c3 to c12 and F3 to F12

        public static void SetTrafficData(int classValue, string c, string F)
        {
            if (classValue > 2)
            {
                if (c != "")
                    Settings.TrafficData[classValue - 3, 0] = TryParseDouble(c);
                if (F != "")
                    Settings.TrafficData[classValue - 3, 1] = TryParseDouble(F);
            }
        }

        private static double GetCF()
        {
            double cF = 0.0;

            for (int i = 0; i < 10; i++)
            {
                cF += CalcHelper.Settings.TrafficData[i, 0] * CalcHelper.Settings.TrafficData[i, 1];
            }

            return cF;
        }

        public static double GetAECperHV()
        {
            return GetCF() / GetHVGrowthRate_r1();
        }

        #endregion c3 to c12 and F3 to F12

        #region R

        public static double GetR()
        {
            if ((Settings.P_PavementDesignLife - Settings.Q_PavementDesignLifeFor_r1) > 0)
            {
                return Settings.R_CumulativeGrowthFactor = CalcR(Settings.r1_HVGrowthRate, Settings.Q_PavementDesignLifeFor_r1) +
                    Math.Pow(1 + Settings.r1_HVGrowthRate, Settings.Q_PavementDesignLifeFor_r1 - 1) * (1 + Settings.r2_HVGrowthRate) *
                    CalcR(Settings.r2_HVGrowthRate, Settings.P_PavementDesignLife - Settings.Q_PavementDesignLifeFor_r1);
            }
            else
            {
                return Settings.R_CumulativeGrowthFactor = Settings.r1_HVGrowthRate > 0 ? CalcR(Settings.r1_HVGrowthRate, Settings.P_PavementDesignLife) : 0;
            }
        }

        private static double CalcR(double r, uint P)
        {
            return (Math.Pow(1 + r, P) - 1) / r;
        }

        #endregion R

        #region ESA

        public static void SetESA(string txt)
        {
            Settings.ESA_DesignTraffic = TryParseDouble(txt);
        }

        public static double GetESA()
        {
            if (Settings.TrafficMethod == TrafficMethod.TrafficMethod2)
            {
                return Settings.ESA_DesignTraffic = 365 * Settings.n_AADT * Settings.d_LaneDistributionFactor * Settings.R_CumulativeGrowthFactor * Settings.c_HVPerc * Settings.F_AxleEquivalencyFactor / 10000.0;
            }
            else
            {
                return Settings.ESA_DesignTraffic = 365 * Settings.n_AADT * Settings.d_LaneDistributionFactor * Settings.R_CumulativeGrowthFactor * GetCF() / 10000.0;
            }
        }

        #endregion ESA

        #region Thickness

        public static double GetThickness(uint cbr)
        {
            return (219.0 - 211.0 * Math.Log10(cbr) + 58.0 * Math.Pow(Math.Log10(cbr), 2)) * Math.Log10(Settings.ESA_DesignTraffic / 120.0);
        }

        public static double GetThicknessGranuar()
        {
            return GetThickness(Settings.CBR_Subgrade);
        }

        public static double GetThicknessGranuarRounded()
        {
            return Math.Ceiling(GetThickness(Settings.CBR_Subgrade) / 5.0) * 5;
        }

        public static double GetThicknessBasecourse()
        {
            return GetThickness(Settings.CBR_Basecourse);
        }

        public static double GetThicknessBasecourseRounded()
        {
            return Math.Ceiling(GetThickness(Settings.CBR_Basecourse) / 5.0) * 5;
        }

        #endregion Thickness
    }
}