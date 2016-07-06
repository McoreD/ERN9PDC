using HelpersLib;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERN9PDC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsGuiReady = false;

        public MainWindow()
        {
            InitializeComponent();
            sliderSubgradeCBR.Value = 12;
            gridC.Visibility = Visibility.Collapsed;
            gridF.Visibility = Visibility.Collapsed;
        }

        #region Pavement data

        private void txtP_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetPavementDesignLife(txtP_PavementDesignLife.Text);

            if (CalcHelper.P_PavementDesignLife > 0)
            {
                sliderQ_PavementDesignLife.Value = sliderQ_PavementDesignLife.Maximum = CalcHelper.P_PavementDesignLife;
            }

            UpdateGuiControls();
        }

        private void sliderSubgradeCBR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalcHelper.SetCbrSubgrade((uint)sliderSubgradeCBR.Value);
            UpdateGuiControls();
        }

        #endregion Pavement data

        private async void btnLaneDistributionFactor_Click(object sender, RoutedEventArgs e)
        {
            LaneDistributionFactorSelector dlg = new LaneDistributionFactorSelector();
            await DialogHost.Show(dlg);
            txtLaneDistributionFactor.Text = CalcHelper.d_LaneDistributionFactor.ToString();
        }

        #region Traffic data

        private void txtAADT_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAADT(txtAADT.Text);

            UpdateGuiControls();
        }

        private void txtHVGrowthRate_r1_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetHVGrowthRate_r1(txtHVGrowthRate_r1.Text);
            UpdateGuiControls();
        }

        private void txtHVGrowthRate_r2_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetHVGrowthRate_r2(txtHVGrowthRate_r2.Text);
            UpdateGuiControls();
        }

        private void sliderQ_PavementDesignLife_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalcHelper.Q_PavementDesignLifeFor_r1 = (uint)sliderQ_PavementDesignLife.Value;

            txtQ_PavementLife.Text = sliderQ_PavementDesignLife.Value.ToString("0");
            txtPavementLifeRemaining.Text = (CalcHelper.P_PavementDesignLife - sliderQ_PavementDesignLife.Value).ToString("0");

            if (sliderQ_PavementDesignLife.Value == sliderQ_PavementDesignLife.Maximum)
            {
                tbr1.Text = "Annual heavy vehicle growth rate, r (%)";
                spGrowthRate2.Visibility = Visibility.Collapsed;
            }
            else
            {
                tbr1.Text = "Annual heavy vehicle growth rates, r1 (%)";
                spGrowthRate2.Visibility = Visibility.Visible;
            }

            UpdateGuiControls();
        }

        #endregion Traffic data

        #region Traffic methods

        private void rbTrafficMethod2_Checked(object sender, RoutedEventArgs e)
        {
            if (IsGuiReady)
            {
                gridC.Visibility = Visibility.Collapsed;
                gridF.Visibility = Visibility.Collapsed;
                btnRandomC.Visibility = Visibility.Hidden;
            }

            CalcHelper.TrafficMethod = TrafficMethod.TrafficMethod2;
        }

        private void rbTrafficMethod1_Checked(object sender, RoutedEventArgs e)
        {
            if (IsGuiReady)
            {
                gridC.Visibility = Visibility.Visible;
                gridF.Visibility = Visibility.Visible;
                btnRandomC.Visibility = Visibility.Visible;
            }

            CalcHelper.TrafficMethod = TrafficMethod.TrafficMethod1;
        }

        #endregion Traffic methods

        #region Traffic Method 1 - Grid for c

        private void txtC3_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(3, txtC3.Text, txtF3.Text);
            UpdateGuiControls();
        }

        private void txtC4_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(4, txtC4.Text, txtF4.Text);
            UpdateGuiControls();
        }

        private void txtC5_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(5, txtC5.Text, txtF5.Text);
            UpdateGuiControls();
        }

        private void txtC6_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(6, txtC6.Text, txtF6.Text);
            UpdateGuiControls();
        }

        private void txtC7_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(7, txtC7.Text, txtF7.Text);
            UpdateGuiControls();
        }

        private void txtC8_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(8, txtC8.Text, txtF8.Text);
            UpdateGuiControls();
        }

        private void txtC9_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(9, txtC9.Text, txtF9.Text);
            UpdateGuiControls();
        }

        private void txtC10_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(10, txtC10.Text, txtF10.Text);
            UpdateGuiControls();
        }

        private void txtC11_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(11, txtC11.Text, txtF11.Text);
            UpdateGuiControls();
        }

        private void txtC12_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetTrafficData(12, txtC12.Text, txtF12.Text);
            UpdateGuiControls();
        }

        #endregion Traffic Method 1 - Grid for c

        private void btnRandomC_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            txtC3.Text = (rnd.NextDouble() * 10).ToString("0.00");
            txtC4.Text = (rnd.NextDouble() * 10).ToString("0.00");
            txtC5.Text = (rnd.NextDouble() * 10).ToString("0.00");
            txtC6.Text = (rnd.NextDouble() * 10).ToString("0.00");
            txtC7.Text = (rnd.NextDouble() * 10).ToString("0.00");
            txtC8.Text = (rnd.NextDouble() * 10).ToString("0.00");
            txtC9.Text = (rnd.NextDouble() * 10).ToString("0.00");
            txtC10.Text = (rnd.NextDouble() * 10).ToString("0.00");
            txtC11.Text = (rnd.NextDouble() * 10).ToString("0.00");
            txtC12.Text = (rnd.NextDouble() * 10).ToString("0.00");

            UpdateGuiControls();
        }

        #region Axle Equivalency Factor methods, F

        private void txtAxleEquivalencyFactor_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactor(txtAxleEquivalencyFactor.Text);
        }

        private async void btnAxleEquivalencyFactor_Click(object sender, RoutedEventArgs e)
        {
            if (CalcHelper.TrafficMethod == TrafficMethod.TrafficMethod2)
            {
                var dlg = new AxleEquivalencyFactorSelector();
                await DialogHost.Show(dlg);

                txtAxleEquivalencyFactor.Text = CalcHelper.F_AxleEquivalencyFactor.ToString();
            }
            else
            {
                var dlg = new AxleEquivalencyFactorsSelector();
                await DialogHost.Show(dlg);

                txtF3.Text = CalcHelper.GetFbyVehicleClass(3).ToString();
                txtF4.Text = CalcHelper.GetFbyVehicleClass(4).ToString();
                txtF5.Text = CalcHelper.GetFbyVehicleClass(5).ToString();
                txtF6.Text = CalcHelper.GetFbyVehicleClass(6).ToString();
                txtF7.Text = CalcHelper.GetFbyVehicleClass(7).ToString();
                txtF8.Text = CalcHelper.GetFbyVehicleClass(8).ToString();
                txtF9.Text = CalcHelper.GetFbyVehicleClass(9).ToString();
                txtF10.Text = CalcHelper.GetFbyVehicleClass(10).ToString();
                txtF11.Text = CalcHelper.GetFbyVehicleClass(11).ToString();
                txtF12.Text = CalcHelper.GetFbyVehicleClass(12).ToString();
            }
        }

        #endregion Axle Equivalency Factor methods, F

        #region ESA

        private void txtESA_DesignTraffic_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetESA(txtESA_DesignTraffic.Text);
            UpdateGuiControls();
        }

        private void btnCalcESA_Click(object sender, RoutedEventArgs e)
        {
            txtESA_DesignTraffic.Text = CalcHelper.GetESA().ToString("G3", CultureInfo.InvariantCulture);
            UpdateGuiControls();
        }

        #endregion ESA

        private async void UpdateGuiControls()
        {
            if (IsGuiReady)
            {
                txtR_CumulativeGrowthFactor.Text = CalcHelper.GetR().ToString();

                if (CalcHelper.TrafficMethod == TrafficMethod.TrafficMethod1)
                {
                    txtHVperc.Text = CalcHelper.GetHVGrowthRate_r1().ToString("0.00");
                    txtAxleEquivalencyFactor.Text = CalcHelper.GetAECperHV().ToString("0.00");
                }

                if (CalcHelper.GetHVGrowthRate_r1() > 100.0) // causes dialog is already open sometimes
                {
                    var dlg = new CustomMessageBox("Total percentage of heavy vehicles is over 100%.");
                    await DialogHost.Show(dlg);
                }
                else
                {
                    txtThicknessGranular.Text = CalcHelper.GetThicknessGranuar().ToString();
                    txtThicknessBasecourse.Text = CalcHelper.GetThicknessBasecourse().ToString();
                    txtThicknessGranularRounded.Text = CalcHelper.GetThicknessGranuarRounded().ToString();
                    txtThicknessBasecourseRounded.Text = CalcHelper.GetThicknessBasecourseRounded().ToString();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IsGuiReady = true;
        }
    }
}