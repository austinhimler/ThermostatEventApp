using System;
using ThermostatEventApp.Interfaces;
using ThermostatEventApp.Models;

namespace ThermostatEventApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Any Key to start device...");
            Console.ReadKey();

            IDevice device = new Device();
            device.RunDevice();

            Console.ReadKey();
        }
    }

    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}