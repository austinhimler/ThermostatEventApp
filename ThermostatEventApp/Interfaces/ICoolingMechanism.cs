using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermostatEventApp.Interfaces
{
    public interface ICoolingMechanism
    {
        void On();
        void Off();
    }
}
