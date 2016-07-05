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
    /// Interaction logic for AxleEquivalencyFactorsSelector.xaml
    /// </summary>
    public partial class AxleEquivalencyFactorsSelector : UserControl
    {
        public AxleEquivalencyFactorsSelector()
        {
            InitializeComponent();

            var itemsGeneral = new List<AxleEquivalencyFactorData1>();
            itemsGeneral.Add(new AxleEquivalencyFactorData1() { Location = "Rural National Highways", F3 = 0.77, F4 = 2.57, F5 = 4.23, F6 = 2.29, F7 = 1.59, F8 = 3.4, F9 = 4.2, F10 = 8.08, F11 = 10.03, F12 = 11.54 });
            itemsGeneral.Add(new AxleEquivalencyFactorData1() { Location = "Rural Highways" });
            itemsGeneral.Add(new AxleEquivalencyFactorData1() { Location = "Rural Main and Secondary Roads" });
            itemsGeneral.Add(new AxleEquivalencyFactorData1() { Location = "Urban Freeways & Highways" });
            itemsGeneral.Add(new AxleEquivalencyFactorData1() { Location = "Other Important Urban Arterial Roads" });
            lvFactorsGeneral.ItemsSource = itemsGeneral;

            var itemsSpecific = new List<AxleEquivalencyFactorData1>();
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Great Eastern Hwy (H005) SLK 102.66, Northam", F3 = 3.27 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Great Northern Hwy (H006) SLK 30, Bullsbrook", F3 = 4.04 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Great Northern Hwy (H006) SLK 35, Muchea", F3 = 3.60 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Victoria Hwy  (40 km East of WA Border)", F3 = 4.06 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Brookton Hwy (H052) SLK 129, Brookton", F3 = 4.14 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "NW Coastal Hwy (H007) SLK 760.4, Nanutarra", F3 = 4.03 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "South Coast Hwy (H008) SLK 468.4, Esperance", F3 = 5.81 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "South Western Hwy (H009) SLK 204.79, Kirup", F3 = 5.21 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "South Western Hwy (H009) SLK 79.29, Waroona", F3 = 2.88 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Geraldton-Mt Magnet Rd (H050) SLK 8.43, Geraldton", F3 = 3.75 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Kwinana Freeway (H015) SLK 56.84, Mandurah", F3 = 2.86 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Kwinana Freeway (H015) SLK 69.05, Pinjarra", F3 = 2.86 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Reid Hwy (H021) SLK 22.65) Middle Swan", F3 = 1.90 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Roe Hwy (H018) SLK 13.03, Jandakot", F3 = 1.99 });
            lvFactorsSpecific.ItemsSource = itemsSpecific;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (CalcHelper.F_AxleEquivalencyFactor > 0)
                btnOk.Command = DialogHost.CloseDialogCommand;
        }

        private void lvFactorsSpecific_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvFactorsGeneral.SelectedIndex = -1;
            if (lvFactorsSpecific.SelectedIndex > -1)
                CalcHelper.SetAxleEquivalencyFactor(((AxleEquivalencyFactorData1)lvFactorsSpecific.SelectedItem).F3);
        }

        private void lvFactorsGeneral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvFactorsSpecific.SelectedIndex = -1;
            if (lvFactorsGeneral.SelectedIndex > -1)
                CalcHelper.SetAxleEquivalencyFactor(((AxleEquivalencyFactorData1)lvFactorsGeneral.SelectedItem).F3);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Command = DialogHost.CloseDialogCommand;
        }
    }
}