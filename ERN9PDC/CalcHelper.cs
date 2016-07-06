﻿using System;
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
        public static double r1_HVGrowthRate { get; private set; } = 0.03;
        public static double r2_HVGrowthRate { get; private set; }
        public static uint d_LaneDistributionFactor { get; private set; } = 100;
        public static double F_AxleEquivalencyFactor { get; private set; }
        public static uint P_PavementDesignLife { get; private set; } = 40;
        public static double R_CumulativeGrowthFactor { get; private set; }
        public static double ESA_DesignTraffic { get; private set; }

        public static AxleEquivalencyFactorData1 F_AxleEquivalencyFactors { get; private set; }
        private static double[,] cF = new double[10, 2]; // 10 pairs array

        public static uint Q_PavementDesignLifeFor_r1 { get; set; }

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

        public static double SetHVGrowthRate_r1()
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
            return GetCF() / SetHVGrowthRate_r1();
        }

        public static void SetHVGrowthRate_r1(string txt)
        {
            double r = TryParseDouble(txt);
            if (r >= 1) r = r / 100.0;
            r1_HVGrowthRate = r;
        }

        public static void SetHVGrowthRate_r2(string txt)
        {
            double r = TryParseDouble(txt);
            if (r >= 1) r = r / 100.0;
            r2_HVGrowthRate = r;
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
            if ((P_PavementDesignLife - Q_PavementDesignLifeFor_r1) > 0)
            {
                return R_CumulativeGrowthFactor = CalcR(r1_HVGrowthRate, Q_PavementDesignLifeFor_r1) +
                    Math.Pow(1 + r1_HVGrowthRate, Q_PavementDesignLifeFor_r1 - 1) * (1 + r2_HVGrowthRate) *
                    CalcR(r2_HVGrowthRate, P_PavementDesignLife - Q_PavementDesignLifeFor_r1);
            }
            else
            {
                return R_CumulativeGrowthFactor = r1_HVGrowthRate > 0 ? CalcR(r1_HVGrowthRate, P_PavementDesignLife) : 0;
            }
        }

        private static double CalcR(double r, uint P)
        {
            return (Math.Pow(1 + r, P) - 1) / r;
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