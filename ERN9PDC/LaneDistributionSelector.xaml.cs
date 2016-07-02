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
    public partial class LaneDistributionSelector : UserControl
    {
        public int d { get; private set; }

        public LaneDistributionSelector()
        {
            InitializeComponent();
            var items = new List<LaneDistribution>();
            items.Add(new LaneDistribution() { Location = "Rural", NumLanes = 1, d = 100 });
            items.Add(new LaneDistribution() { Location = "Rural", NumLanes = 2, d = 95 });
            items.Add(new LaneDistribution() { Location = "Rural", NumLanes = 3, d = 95 });
            items.Add(new LaneDistribution() { Location = "Urban", NumLanes = 1, d = 100 });
            items.Add(new LaneDistribution() { Location = "Urban", NumLanes = 2, d = 80 });
            items.Add(new LaneDistribution() { Location = "Urban", NumLanes = 3, d = 65 });
            lvLaneDistribution.ItemsSource = items;
            lvLaneDistribution.SelectedIndex = 3;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (lvLaneDistribution.SelectedIndex > 0)
            {
                d = ((LaneDistribution)lvLaneDistribution.SelectedItem).d;
                btnOk.Command = DialogHost.CloseDialogCommand;
            }
        }
    }
}