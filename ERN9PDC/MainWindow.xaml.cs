using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
            CalcHelper.CalcR();
        }
    }
}