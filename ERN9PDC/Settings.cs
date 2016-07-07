using HelpersLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERN9PDC
{
    public class Settings : SettingsBase<Settings>
    {
        public TrafficMethod TrafficMethod { get; set; } = TrafficMethod.TrafficMethod2;

        public uint P_PavementDesignLife { get; set; } = 40;
        public uint CBR_Subgrade { get; set; } = 12;
        public uint CBR_Basecourse { get; set; } = 30;
        public uint n_AADT { get; set; } = 1000;
        public double c_HVPerc { get; set; } = 6.8;
        public double r1_HVGrowthRate { get; set; } = 0.03;
        public uint Q_PavementDesignLifeFor_r1 { get; set; }
        public double r2_HVGrowthRate { get; set; }
        public uint d_LaneDistributionFactor { get; set; } = 100;
        public double F_AxleEquivalencyFactor { get; set; }
        public double[,] TrafficData = new double[10, 2]; // [0,0] is Class 3, c; [0,1] is Class 3, F; [1,0] is Class 4, c etc.
        public double R_CumulativeGrowthFactor { get; set; }
        public double ESA_DesignTraffic { get; set; }

        public void WriteCsv(string fp)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pavement design life,P, {P_PavementDesignLife}");
            sb.AppendLine($"Subgrade CBR,CBR, {CBR_Subgrade}");
            sb.AppendLine($"Traffic method used, {TrafficMethod.GetDescription()}");
            sb.AppendLine($"Initial number of vehicles daily in one direction (1-way AADT),n, {n_AADT}");

            if (Q_PavementDesignLifeFor_r1 <= P_PavementDesignLife)
            {
                sb.AppendLine($"Annual heavy vehicle growth rate (%),r, {r1_HVGrowthRate}");
            }
            else
            {
                sb.AppendLine($"Annual heavy vehicle growth rate (%),r1, {r1_HVGrowthRate}");
                sb.AppendLine($"First period (years),Q, {Q_PavementDesignLifeFor_r1}");
                sb.AppendLine($"Annual heavy vehicle growth rate (%),r2, {r1_HVGrowthRate}");
                sb.AppendLine($"Remaining period (years),P-Q, {P_PavementDesignLife - Q_PavementDesignLifeFor_r1}");
            }

            sb.AppendLine($"Percentage of heavy vehicles using design lane (%),, {d_LaneDistributionFactor}");

            if (TrafficMethod == TrafficMethod.TrafficMethod2)
            {
                sb.AppendLine($"Percentage of heavy vehicles (%),c, {c_HVPerc}");
                sb.AppendLine($"Axle Equivalency Factor,F, {F_AxleEquivalencyFactor}");
            }
            else
            {
                sb.AppendLine($"Percentage of heavy vehicles and axle equivalency factor by vehicle class");
                for (int i = 0; i < 10; i++)
                {
                    sb.AppendLine($"Class {i + 3}, c{i + 3},{TrafficData[i, 0]}, F{i + 3}, {TrafficData[i, 1]}");
                }
                sb.AppendLine($"Percentage of heavy vehicles (%),c, {c_HVPerc}");
                sb.AppendLine($"Axle Equivalency Factor,ESA/HV, {F_AxleEquivalencyFactor}");
            }

            sb.AppendLine($"Cumulative growth factor,R, {R_CumulativeGrowthFactor}");
            sb.AppendLine($"Calculated design traffic (ESA),ESA, {ESA_DesignTraffic}");

            sb.AppendLine($"Minimum thickness of all granular material (mm),t_granular, {CalcHelper.GetThicknessGranuarRounded()}");
            sb.AppendLine($"Minimum thickness of basecourse material (mm),t_basecourse, {CalcHelper.GetThicknessBasecourseRounded()}");

            File.WriteAllText(fp, sb.ToString(), Encoding.UTF8);
        }
    }
}