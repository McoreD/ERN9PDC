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
        }

        private void sliderSubgradeCBR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalcHelper.SetCbrSubgrade((uint)sliderSubgradeCBR.Value);
            UpdateGuiControls();
        }

        private async void btnLaneDistributionFactor_Click(object sender, RoutedEventArgs e)
        {
            LaneDistributionFactorSelector dlg = new LaneDistributionFactorSelector();
            await DialogHost.Show(dlg);
            txtLaneDistributionFactor.Text = CalcHelper.d_LaneDistributionFactor.ToString();
        }

        private async void btnAxleEquivalencyFactor_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AxleEquivalencyFactorSelector();
            await DialogHost.Show(dlg);
            txtAxleEquivalencyFactor.Text = CalcHelper.F_AxleEquivalencyFactor.ToString();
        }

        private void txtAADT_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAADT(txtAADT.Text);

            UpdateGuiControls();
        }

        private void txtP_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetPavmentDesignLife(txtP_PavementDesignLife.Text);
            UpdateGuiControls();
        }

        private void txtr_HeavyTrafficGrowtRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetHeavyVehiclePercentage(txtr_HeavyTrafficGrowtRate.Text);
            UpdateGuiControls();
        }

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

        private void txtAxleEquivalencyFactor_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactor(txtAxleEquivalencyFactor.Text);
        }

        private async void UpdateGuiControls()
        {
            if (IsGuiReady)
            {
                txtR_CumulativeGrowthFactor.Text = CalcHelper.GetR().ToString();

                tbHVPerc.Text = CalcHelper.SetHeavyVehiclePercentage().ToString("0.00");
                tbF.Text = CalcHelper.GetAECperHV().ToString("0.00");

                if (CalcHelper.SetHeavyVehiclePercentage() > 100.0) // causes dialog is already open sometimes
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

        private async void btnAxleEquivalencyFactors_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AxleEquivalencyFactorsSelector();
            await DialogHost.Show(dlg);
        }

        private void tcTrafficMethods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcHelper.TrafficMethod = (TrafficMethod)tcTrafficMethods.SelectedIndex;
        }

        private void txtC3_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(3, txtC3.Text, txtF3.Text);
            UpdateGuiControls();
        }

        private void txtC4_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(4, txtC4.Text, txtF4.Text);
            UpdateGuiControls();
        }

        private void txtC5_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(5, txtC5.Text, txtF5.Text);
            UpdateGuiControls();
        }

        private void txtC6_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(6, txtC6.Text, txtF6.Text);
            UpdateGuiControls();
        }

        private void txtC7_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(7, txtC7.Text, txtF7.Text);
            UpdateGuiControls();
        }

        private void txtC8_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(8, txtC8.Text, txtF8.Text);
            UpdateGuiControls();
        }

        private void txtC9_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(9, txtC9.Text, txtF9.Text);
            UpdateGuiControls();
        }

        private void txtC10_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(10, txtC10.Text, txtF10.Text);
            UpdateGuiControls();
        }

        private void txtC11_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(11, txtC11.Text, txtF11.Text);
            UpdateGuiControls();
        }

        private void txtC12_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcHelper.SetAxleEquivalencyFactors(12, txtC12.Text, txtF12.Text);
            UpdateGuiControls();
        }
    }
}