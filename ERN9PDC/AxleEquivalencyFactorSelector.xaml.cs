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
            var itemsGeneral = new List<AxleEquivalencyFactorData>();
            itemsGeneral.Add(new AxleEquivalencyFactorData() { Location = "Rural National Highways", AxleEquivalencyFactor = 5.81 });
            itemsGeneral.Add(new AxleEquivalencyFactorData() { Location = "Rural Highways", AxleEquivalencyFactor = 5.81 });
            itemsGeneral.Add(new AxleEquivalencyFactorData() { Location = "Rural Main and Secondary Roads", AxleEquivalencyFactor = 3.75 });
            itemsGeneral.Add(new AxleEquivalencyFactorData() { Location = "Urban Freeways & Highways", AxleEquivalencyFactor = 1.99 });
            itemsGeneral.Add(new AxleEquivalencyFactorData() { Location = "Other Important Urban Arterial Roads", AxleEquivalencyFactor = 1.99 });
            lvFactorsGeneral.ItemsSource = itemsGeneral;

            var itemsSpecific = new List<AxleEquivalencyFactorData>();
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Great Eastern Hwy (H005) SLK 102.66, Northam", AxleEquivalencyFactor = 3.27 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Great Northern Hwy (H006) SLK 30, Bullsbrook", AxleEquivalencyFactor = 4.04 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Great Northern Hwy (H006) SLK 35, Muchea", AxleEquivalencyFactor = 3.60 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Victoria Hwy  (40 km East of WA Border)", AxleEquivalencyFactor = 4.06 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Brookton Hwy (H052) SLK 129, Brookton", AxleEquivalencyFactor = 4.14 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "NW Coastal Hwy (H007) SLK 760.4, Nanutarra", AxleEquivalencyFactor = 4.03 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "South Coast Hwy (H008) SLK 468.4, Esperance", AxleEquivalencyFactor = 5.81 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "South Western Hwy (H009) SLK 204.79, Kirup", AxleEquivalencyFactor = 5.21 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "South Western Hwy (H009) SLK 79.29, Waroona", AxleEquivalencyFactor = 2.88 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Geraldton-Mt Magnet Rd (H050) SLK 8.43, Geraldton", AxleEquivalencyFactor = 3.75 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Kwinana Freeway (H015) SLK 56.84, Mandurah", AxleEquivalencyFactor = 2.86 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Kwinana Freeway (H015) SLK 69.05, Pinjarra", AxleEquivalencyFactor = 2.86 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Reid Hwy (H021) SLK 22.65) Middle Swan", AxleEquivalencyFactor = 1.90 });
            itemsSpecific.Add(new AxleEquivalencyFactorData() { Location = "Roe Hwy (H018) SLK 13.03, Jandakot", AxleEquivalencyFactor = 1.99 });
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
                CalcHelper.SetAxleEquivalencyFactor(((AxleEquivalencyFactorData)lvFactorsSpecific.SelectedItem).AxleEquivalencyFactor);
        }

        private void lvFactorsGeneral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvFactorsSpecific.SelectedIndex = -1;
            if (lvFactorsGeneral.SelectedIndex > -1)
                CalcHelper.SetAxleEquivalencyFactor(((AxleEquivalencyFactorData)lvFactorsGeneral.SelectedItem).AxleEquivalencyFactor);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Command = DialogHost.CloseDialogCommand;
        }
    }
}