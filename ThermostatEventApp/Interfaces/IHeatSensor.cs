using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermostatEventApp.Interfaces
{
    public interface IHeatSensor
    {
        event EventHandler<TemperatureEventArgs> TempEmergencyEventHandler;
        event EventHandler<TemperatureEventArgs> TempWarningEventHandler;
        event EventHandler<TemperatureEventArgs> TempBelowWarningEventHandler;
        void RunHeatSensor();
    }
}
