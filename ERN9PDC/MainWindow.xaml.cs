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

        private async void btnLaneDistribution(object sender, RoutedEventArgs e)
        {
            LaneDistributionSelector dlg = new LaneDistributionSelector();
            await DialogHost.Show(dlg);
            txtDistributionFactor.Text = dlg.d.ToString();
        }
    }
}