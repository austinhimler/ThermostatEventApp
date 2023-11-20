using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThermostatEventApp.Interfaces;

namespace ThermostatEventApp.Models
{
    public class CoolingMechanism : ICoolingMechanism
    {
        public void Off()
        {
            Console.WriteLine();
            Console.WriteLine("Switching cooling mechanism off...");
            Console.WriteLine();
        }

        public void On()
        {
            Console.WriteLine();
            Console.WriteLine("Switching cooling mechanism on...");
            Console.WriteLine();
        }
    }
}
