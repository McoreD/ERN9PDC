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
    /// Interaction logic for AxleEquivalencyFactorSelector.xaml
    /// </summary>
    public partial class AxleEquivalencyFactorSelector : UserControl
    {
        public AxleEquivalencyFactorSelector()
        {
            InitializeComponent();

            var itemsGeneral = new List<AxleEquivalencyFactorData2>();
            itemsGeneral.Add(new AxleEquivalencyFactorData2() { Location = "Rural National Highways", F = 5.81 });
            itemsGeneral.Add(new AxleEquivalencyFactorData2() { Location = "Rural Highways", F = 5.81 });
            itemsGeneral.Add(new AxleEquivalencyFactorData2() { Location = "Rural Main and Secondary Roads", F = 3.75 });
            itemsGeneral.Add(new AxleEquivalencyFactorData2() { Location = "Urban Freeways & Highways", F = 1.99 });
            itemsGeneral.Add(new AxleEquivalencyFactorData2() { Location = "Other Important Urban Arterial Roads", F = 1.99 });
            lvFactorsGeneral.ItemsSource = itemsGeneral;

            var itemsSpecific = new List<AxleEquivalencyFactorData2>();
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Great Eastern Hwy (H005) SLK 102.66, Northam", F = 3.27 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Great Northern Hwy (H006) SLK 30, Bullsbrook", F = 4.04 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Great Northern Hwy (H006) SLK 35, Muchea", F = 3.60 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Victoria Hwy  (40 km East of WA Border)", F = 4.06 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Brookton Hwy (H052) SLK 129, Brookton", F = 4.14 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "NW Coastal Hwy (H007) SLK 760.4, Nanutarra", F = 4.03 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "South Coast Hwy (H008) SLK 468.4, Esperance", F = 5.81 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "South Western Hwy (H009) SLK 204.79, Kirup", F = 5.21 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "South Western Hwy (H009) SLK 79.29, Waroona", F = 2.88 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Geraldton-Mt Magnet Rd (H050) SLK 8.43, Geraldton", F = 3.75 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Kwinana Freeway (H015) SLK 56.84, Mandurah", F = 2.86 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Kwinana Freeway (H015) SLK 69.05, Pinjarra", F = 2.86 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Reid Hwy (H021) SLK 22.65) Middle Swan", F = 1.90 });
            itemsSpecific.Add(new AxleEquivalencyFactorData2() { Location = "Roe Hwy (H018) SLK 13.03, Jandakot", F = 1.99 });
            lvFactorsSpecific.ItemsSource = itemsSpecific;
        }

        private void lvFactorsGeneral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvFactorsSpecific.SelectedIndex = -1;
            if (lvFactorsGeneral.SelectedIndex > -1)
                CalcHelper.SetAxleEquivalencyFactor(((AxleEquivalencyFactorData2)lvFactorsGeneral.SelectedItem).F);
        }

        private void lvFactorsSpecific_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvFactorsGeneral.SelectedIndex = -1;
            if (lvFactorsSpecific.SelectedIndex > -1)
                CalcHelper.SetAxleEquivalencyFactor(((AxleEquivalencyFactorData2)lvFactorsSpecific.SelectedItem).F);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (CalcHelper.F_AxleEquivalencyFactor > 0)
                btnOk.Command = DialogHost.CloseDialogCommand;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Command = DialogHost.CloseDialogCommand;
        }
    }
}