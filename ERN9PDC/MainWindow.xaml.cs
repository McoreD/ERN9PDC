﻿using MaterialDesignThemes.Wpf;
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
        public MainWindow()
        {
            InitializeComponent();
            cboSubgradeCBR.ItemsSource = Enumerable.Range(1, 30);
        }

        private async void btnLaneDistributionFactor_Click(object sender, RoutedEventArgs e)
        {
            LaneDistributionFactorSelector dlg = new LaneDistributionFactorSelector();
            await DialogHost.Show(dlg);
            txtLaneDistributionFactor.Text = CalcHelper.d_LaneDistributionFactor.ToString();
        }

        private async void btnAxleEquivalencyFactor_Click(object sender, RoutedEventArgs e)
        {
            AxleEquivalencyFactorSelector dlg = new AxleEquivalencyFactorSelector();
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
            txtR_CumulativeGrowthFactor.Text = CalcHelper.GetR().ToString();
            txtThicknessGranular.Text = CalcHelper.GetThicknessGranuar().ToString();
            txtThicknessBasecourse.Text = CalcHelper.GetThicknessBasecourse().ToString();
            txtThicknessGranularRounded.Text = CalcHelper.GetThicknessGranuarRounded().ToString();
            txtThicknessBasecourseRounded.Text = CalcHelper.GetThicknessBasecourseRounded().ToString();
        }

        private void cboSubgradeCBR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uint cbr = 12;
            uint.TryParse(cboSubgradeCBR.SelectedValue.ToString(), out cbr);
            CalcHelper.SetCbrSubgrade(cbr);
        }
    }
}