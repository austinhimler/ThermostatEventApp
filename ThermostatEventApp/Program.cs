using System;

namespace ThermostatEventApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Any Key to start device...");
            Console.ReadKey();

            //run device

            Console.ReadKey();
        }
    }

    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}