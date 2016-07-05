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

        private void UpdateGuiControls()
        {
            if (IsGuiReady)
            {
                txtR_CumulativeGrowthFactor.Text = CalcHelper.GetR().ToString();
                txtThicknessGranular.Text = CalcHelper.GetThicknessGranuar().ToString();
                txtThicknessBasecourse.Text = CalcHelper.GetThicknessBasecourse().ToString();
                txtThicknessGranularRounded.Text = CalcHelper.GetThicknessGranuarRounded().ToString();
                txtThicknessBasecourseRounded.Text = CalcHelper.GetThicknessBasecourseRounded().ToString();
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
    }
}