using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERN9PDC
{
    public class TrafficData
    {
        public string VehicleClass { get; set; }
        public double HeavyVehiclePercentage { get; set; }
        public double HeavyVehicleAxleEquivalencyFactor { get; set; }

        public static List<TrafficData> GetTrafficDataMethod1()
        {
            List<TrafficData> list = new List<TrafficData>();

            list.Add(new TrafficData() { VehicleClass = "Class 3" });
            list.Add(new TrafficData() { VehicleClass = "Class 4" });
            list.Add(new TrafficData() { VehicleClass = "Class 5" });
            list.Add(new TrafficData() { VehicleClass = "Class 6" });
            list.Add(new TrafficData() { VehicleClass = "Class 7" });
            list.Add(new TrafficData() { VehicleClass = "Class 8" });
            list.Add(new TrafficData() { VehicleClass = "Class 9" });
            list.Add(new TrafficData() { VehicleClass = "Class 10" });
            list.Add(new TrafficData() { VehicleClass = "Class 11" });
            list.Add(new TrafficData() { VehicleClass = "Class 12" });

            return list;
        }
    }
}