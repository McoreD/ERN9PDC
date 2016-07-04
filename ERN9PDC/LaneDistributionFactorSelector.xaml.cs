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
using System.Windows.Shapes;

namespace ERN9PDC
{
    /// <summary>
    /// Interaction logic for LaneDistributionSelector.xaml
    /// </summary>
    public partial class LaneDistributionFactorSelector : UserControl
    {
        public LaneDistributionFactorSelector()
        {
            InitializeComponent();
            var items = new List<LaneDistributionData>();
            items.Add(new LaneDistributionData() { Location = "Rural", Lanes = 1, DistributionFactor = 100 });
            items.Add(new LaneDistributionData() { Location = "Rural", Lanes = 2, DistributionFactor = 95 });
            items.Add(new LaneDistributionData() { Location = "Rural", Lanes = 3, DistributionFactor = 95 });
            items.Add(new LaneDistributionData() { Location = "Urban", Lanes = 1, DistributionFactor = 100 });
            items.Add(new LaneDistributionData() { Location = "Urban", Lanes = 2, DistributionFactor = 80 });
            items.Add(new LaneDistributionData() { Location = "Urban", Lanes = 3, DistributionFactor = 65 });
            lvFactors.ItemsSource = items;
            lvFactors.SelectedIndex = 3;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (CalcHelper.d_LaneDistributionFactor > 0)
                btnOk.Command = DialogHost.CloseDialogCommand;
        }

        private void lvFactors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcHelper.SetLaneDistributionFactor(((LaneDistributionData)lvFactors.SelectedItem).DistributionFactor);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnOk.Command = DialogHost.CloseDialogCommand;
        }
    }
}