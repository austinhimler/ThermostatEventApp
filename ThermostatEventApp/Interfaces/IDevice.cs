using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermostatEventApp.Interfaces
{
    public interface IDevice
    {
        double WarningTemperature { get; }
        double EmergencyTemperature { get; }
        void RunDevice();
        void HandleEmergency();
    }
}
