using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThermostatEventApp.Interfaces;

namespace ThermostatEventApp.Models
{
    public class Device : IDevice
    {
        const double Warning_Level = 27;
        const double Emergency_Level = 75;
        public double WarningTemperature => Warning_Level;

        public double EmergencyTemperature => Emergency_Level;

        public void HandleEmergency()
        {
            Console.WriteLine();
            Console.WriteLine("Sending out notifications to emergency services personal...");
            
        }

        private void ShutDownDevice()
        {
            Console.WriteLine("Shutting down device...");
        }

        public void RunDevice()
        {
            Console.WriteLine("Device is running");

            ICoolingMechanism coolingMechanism = new CoolingMechanism();
            IHeatSensor heatSensor = new HeatSensor(Warning_Level, Emergency_Level);
            IThermostat thermostat = new Thermostat(this, heatSensor, coolingMechanism);

            thermostat.RunThermostat();
        }
    }
}
