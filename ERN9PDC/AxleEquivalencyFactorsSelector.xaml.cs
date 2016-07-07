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
            itemsGeneral.Add(new AxleEquivalencyFactorData1() { Location = "Rural Highways", F3 = 0.77, F4 = 2.57, F5 = 4.23, F6 = 2.29, F7 = 1.59, F8 = 3.4, F9 = 4.2, F10 = 8.08, F11 = 10.03, F12 = 11.54 });
            itemsGeneral.Add(new AxleEquivalencyFactorData1() { Location = "Rural Main and Secondary Roads", F3 = 0.23, F4 = 1.09, F5 = 3.24, F6 = 0.96, F7 = 0.6, F8 = 2.9, F9 = 3.13, F10 = 5.64, F11 = 7.26, F12 = 7.87 });
            itemsGeneral.Add(new AxleEquivalencyFactorData1() { Location = "Urban Freeways & Highways", F3 = 0.68, F4 = 2.3, F5 = 2.67, F6 = 1.3, F7 = 1.48, F8 = 2.95, F9 = 3.42, F10 = 4.74, F11 = 5.84, F12 = 6.98 });
            itemsGeneral.Add(new AxleEquivalencyFactorData1() { Location = "Other Important Urban Arterial Roads", F3 = 0.68, F4 = 2.3, F5 = 2.67, F6 = 1.3, F7 = 1.48, F8 = 2.95, F9 = 3.42, F10 = 4.74, F11 = 5.84, F12 = 6.98 });
            lvFactorsGeneral.ItemsSource = itemsGeneral;

            var itemsSpecific = new List<AxleEquivalencyFactorData1>();
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Great Eastern Hwy (H005) SLK 102.66, Northam", F3 = 0.49, F4 = 2.05, F5 = 2.67, F6 = 0.9, F7 = 1.48, F8 = 2.4, F9 = 3.24, F10 = 4.38, F11 = 5.33, F12 = 9.08 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Great Northern Hwy (H006) SLK 30, Bullsbrook", F3 = 0.49, F4 = 2.32, F5 = 4.16, F6 = 0.7, F7 = 1.06, F8 = 3.01, F9 = 3.82, F10 = 6.63, F11 = 6.89, F12 = 9.08 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Great Northern Hwy (H006) SLK 35, Muchea", F3 = 0.61, F4 = 2.3, F5 = 3.53, F6 = 0.78, F7 = 1.03, F8 = 2.95, F9 = 3.42, F10 = 4.74, F11 = 5.84, F12 = 9.08 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Victoria Hwy  (40 km East of WA Border)", F3 = 0.33, F4 = 1.6, F5 = 2.5, F6 = 0.15, F7 = 0.55, F8 = 1.91, F9 = 4.35, F10 = 4.84, F11 = 6.23, F12 = 9.08 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Brookton Hwy (H052) SLK 129, Brookton", F3 = 0.64, F4 = 2.08, F5 = 3.1, F6 = 2.29, F7 = 1.38, F8 = 3.4, F9 = 3.46, F10 = 5.04, F11 = 8.25, F12 = 11.54 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "NW Coastal Hwy (H007) SLK 760.4, Nanutarra", F3 = 0.63, F4 = 2.57, F5 = 3.28, F6 = 0.55, F7 = 1.59, F8 = 3.15, F9 = 4.2, F10 = 5.05, F11 = 6.33, F12 = 11.54 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "South Coast Hwy (H008) SLK 468.4, Esperance", F3 = 0.44, F4 = 1.89, F5 = 1.77, F6 = 0.52, F7 = 1.1, F8 = 2.09, F9 = 2.85, F10 = 5.07, F11 = 10.03, F12 = 11.54 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "South Western Hwy (H009) SLK 204.79, Kirup", F3 = 0.77, F4 = 2.22, F5 = 2.82, F6 = 0.86, F7 = 1.11, F8 = 3.07, F9 = 4.1, F10 = 8.08, F11 = 9.95, F12 = 11.54 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "South Western Hwy (H009) SLK 79.29, Waroona", F3 = 0.73, F4 = 2.47, F5 = 4.23, F6 = 1.39, F7 = 1.55, F8 = 3.37, F9 = 3.51, F10 = 4.61, F11 = 5.33, F12 = 11.54 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Geraldton-Mt Magnet Rd (H050) SLK 8.43, Geraldton", F3 = 0.23, F4 = 1.09, F5 = 3.24, F6 = 0.96, F7 = 0.6, F8 = 2.9, F9 = 3.13, F10 = 5.64, F11 = 7.26, F12 = 7.87 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Kwinana Freeway (H015) SLK 56.84, Mandurah", F3 = 0.49, F4 = 2.63, F5 = 2.8, F6 = 0.68, F7 = 1.49, F8 = 3.73, F9 = 4.69, F10 = 6.79, F11 = 8.88, F12 = 11.54 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Kwinana Freeway (H015) SLK 69.05, Pinjarra", F3 = 0.48, F4 = 2.3, F5 = 2.66, F6 = 0.55, F7 = 1.33, F8 = 3.05, F9 = 3.74, F10 = 5.16, F11 = 6.88, F12 = 11.54 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Reid Hwy (H021) SLK 22.65) Middle Swan", F3 = 0.4, F4 = 2.62, F5 = 3.66, F6 = 0.66, F7 = 0.76, F8 = 3.31, F9 = 4.52, F10 = 3.72, F11 = 5.67, F12 = 6.98 });
            itemsSpecific.Add(new AxleEquivalencyFactorData1() { Location = "Roe Hwy (H018) SLK 13.03, Jandakot", F3 = 0.68, F4 = 1.96, F5 = 2.06, F6 = 1.3, F7 = 1.32, F8 = 2.48, F9 = 3.06, F10 = 4.28, F11 = 5.13, F12 = 6.98 });
            lvFactorsSpecific.ItemsSource = itemsSpecific;
        }

        private void lvFactorsGeneral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvFactorsSpecific.SelectedIndex = -1;
            if (lvFactorsGeneral.SelectedIndex > -1)
                SetFbyVehicleClass((AxleEquivalencyFactorData1)lvFactorsGeneral.SelectedItem);
        }

        private void lvFactorsSpecific_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvFactorsGeneral.SelectedIndex = -1;
            if (lvFactorsSpecific.SelectedIndex > -1)
                SetFbyVehicleClass((AxleEquivalencyFactorData1)lvFactorsSpecific.SelectedItem);
        }

        private void SetFbyVehicleClass(AxleEquivalencyFactorData1 data)
        {
            CalcHelper.SetFbyVehicleClass(3, data.F3);
            CalcHelper.SetFbyVehicleClass(4, data.F4);
            CalcHelper.SetFbyVehicleClass(5, data.F5);
            CalcHelper.SetFbyVehicleClass(6, data.F6);
            CalcHelper.SetFbyVehicleClass(7, data.F7);
            CalcHelper.SetFbyVehicleClass(8, data.F8);
            CalcHelper.SetFbyVehicleClass(9, data.F9);
            CalcHelper.SetFbyVehicleClass(10, data.F10);
            CalcHelper.SetFbyVehicleClass(11, data.F11);
            CalcHelper.SetFbyVehicleClass(12, data.F12);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (CalcHelper.Settings.F_AxleEquivalencyFactor > 0 || CalcHelper.GetFbyVehicleClass(3) > 0)
                btnOk.Command = DialogHost.CloseDialogCommand;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Command = DialogHost.CloseDialogCommand;
        }
    }
}