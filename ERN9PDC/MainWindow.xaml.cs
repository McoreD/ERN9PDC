﻿using HelpersLib;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
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

        private async Task<bool> IsNumeric(TextBox textBox)
        {
            bool isNumber = textBox.Text.IsNumber();

            if (textBox.Text.Length > 0 && !isNumber)
            {
                var dlg = new CustomMessageBox("Entered value is not numeric.");
                await DialogHost.Show(dlg);
                textBox.Clear();
                textBox.Focus();
            }

            return isNumber;
        }

        public MainWindow()
        {
            InitializeComponent();
            sliderSubgradeCBR.Value = 12;
            gridC.Visibility = Visibility.Collapsed;
            gridF.Visibility = Visibility.Collapsed;
        }

        #region Pavement data

        private async void txtP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtP_PavementDesignLife))
            {
                CalcHelper.SetPavementDesignLife(txtP_PavementDesignLife.Text);

                if (CalcHelper.Settings.P_PavementDesignLife > 0)
                {
                    spGrowthRate1.Visibility = Visibility.Visible;
                    sliderQ_PavementDesignLife.Value = sliderQ_PavementDesignLife.Maximum = CalcHelper.Settings.P_PavementDesignLife;
                }

                UpdateGuiControls();
            }
        }

        private void sliderSubgradeCBR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalcHelper.SetCbrSubgrade((uint)sliderSubgradeCBR.Value);
            UpdateGuiControls();
        }

        #endregion Pavement data

        #region Traffic data

        private async void txtAADT_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtAADT))
            {
                CalcHelper.SetAADT(txtAADT.Text);
                UpdateGuiControls();
            }
        }

        private async void txtHVGrowthRate_r1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtHVGrowthRate_r1))
            {
                CalcHelper.SetHVGrowthRate_r1(txtHVGrowthRate_r1.Text);
                UpdateGuiControls();
            }
        }

        private async void txtHVGrowthRate_r2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtHVGrowthRate_r2))
            {
                CalcHelper.SetHVGrowthRate_r2(txtHVGrowthRate_r2.Text);
                UpdateGuiControls();
            }
        }

        private async void txtLaneDistributionFactor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtLaneDistributionFactor))
            {
                CalcHelper.SetLaneDistributionFactor(txtLaneDistributionFactor.Text);
                UpdateGuiControls();
            }
        }

        private async void btnLaneDistributionFactor_Click(object sender, RoutedEventArgs e)
        {
            LaneDistributionFactorSelector dlg = new LaneDistributionFactorSelector();
            await DialogHost.Show(dlg);
            txtLaneDistributionFactor.Text = CalcHelper.Settings.d_LaneDistributionFactor.ToString();
        }

        private void sliderQ_PavementDesignLife_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalcHelper.Settings.Q_PavementDesignLifeFor_r1 = (uint)sliderQ_PavementDesignLife.Value;

            txtQ_PavementLife.Text = sliderQ_PavementDesignLife.Value.ToString("0");
            txtPavementLifeRemaining.Text = (CalcHelper.Settings.P_PavementDesignLife - sliderQ_PavementDesignLife.Value).ToString("0");

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

        #region Traffic methods - Radio Buttons

        private void rbTrafficMethod2_Checked(object sender, RoutedEventArgs e)
        {
            if (IsGuiReady)
            {
                gridC.Visibility = Visibility.Collapsed;
                gridF.Visibility = Visibility.Collapsed;
                btnRandomC.Visibility = Visibility.Hidden;
            }

            CalcHelper.Settings.TrafficMethod = TrafficMethod.TrafficMethod2;
        }

        private void rbTrafficMethod1_Checked(object sender, RoutedEventArgs e)
        {
            if (IsGuiReady)
            {
                gridC.Visibility = Visibility.Visible;
                gridF.Visibility = Visibility.Visible;
                btnRandomC.Visibility = Visibility.Visible;
            }

            CalcHelper.Settings.TrafficMethod = TrafficMethod.TrafficMethod1;
        }

        #endregion Traffic methods - Radio Buttons

        #region Traffic Method 1 - Grid for c

        private async void txtC3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC3))
            {
                CalcHelper.SetTrafficData(3, txtC3.Text, txtF3.Text);
                UpdateGuiControls();
            }
        }

        private async void txtC4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC4))
            {
                CalcHelper.SetTrafficData(4, txtC4.Text, txtF4.Text);
                UpdateGuiControls();
            }
        }

        private async void txtC5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC5))
            {
                CalcHelper.SetTrafficData(5, txtC5.Text, txtF5.Text);
                UpdateGuiControls();
            }
        }

        private async void txtC6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC6))
            {
                CalcHelper.SetTrafficData(6, txtC6.Text, txtF6.Text);
                UpdateGuiControls();
            }
        }

        private async void txtC7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC7))
            {
                CalcHelper.SetTrafficData(7, txtC7.Text, txtF7.Text);
                UpdateGuiControls();
            }
        }

        private async void txtC8_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC8))
            {
                CalcHelper.SetTrafficData(8, txtC8.Text, txtF8.Text);
                UpdateGuiControls();
            }
        }

        private async void txtC9_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC9))
            {
                CalcHelper.SetTrafficData(9, txtC9.Text, txtF9.Text);
                UpdateGuiControls();
            }
        }

        private async void txtC10_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC10))
            {
                CalcHelper.SetTrafficData(10, txtC10.Text, txtF10.Text);
                UpdateGuiControls();
            }
        }

        private async void txtC11_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC11))
            {
                CalcHelper.SetTrafficData(11, txtC11.Text, txtF11.Text);
                UpdateGuiControls();
            }
        }

        private async void txtC12_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtC12))
            {
                CalcHelper.SetTrafficData(12, txtC12.Text, txtF12.Text);
                UpdateGuiControls();
            }
        }

        #endregion Traffic Method 1 - Grid for c

        #region Traffic Method 2 for c

        private async void txtHVperc_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtHVperc))
                CalcHelper.SetHVPerc(txtHVperc.Text);
        }

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

        #endregion Traffic Method 2 for c

        #region Axle Equivalency Factor methods, F

        private async void txtAxleEquivalencyFactor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (await IsNumeric(txtAxleEquivalencyFactor))
                CalcHelper.SetAxleEquivalencyFactor(txtAxleEquivalencyFactor.Text);
        }

        private async void btnAxleEquivalencyFactor_Click(object sender, RoutedEventArgs e)
        {
            if (CalcHelper.Settings.TrafficMethod == TrafficMethod.TrafficMethod2)
            {
                var dlg = new AxleEquivalencyFactorSelector();
                await DialogHost.Show(dlg);

                txtAxleEquivalencyFactor.Text = CalcHelper.Settings.F_AxleEquivalencyFactor.ToString();
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

                if (CalcHelper.Settings.TrafficMethod == TrafficMethod.TrafficMethod1)
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Comma Separated Values (*.csv)|*.csv";
            if (dlg.ShowDialog() == true)
            {
                CalcHelper.Settings.WriteCsv(dlg.FileName);
            }
        }
    }
}