using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThermostatEventApp.Interfaces;

namespace ThermostatEventApp.Models
{
    public class Thermostat : IThermostat
    {
        private ICoolingMechanism _coolingMechanism = null;
        private IHeatSensor _heatSensor = null;
        private IDevice _device = null;

        public Thermostat(IDevice device, IHeatSensor heatSensor, ICoolingMechanism coolingMechanism)
        {
            _device = device;
            _coolingMechanism = coolingMechanism;
            _heatSensor = heatSensor;
        }
        public void RunThermostat()
        {
            throw new NotImplementedException();
        }
    }
}
