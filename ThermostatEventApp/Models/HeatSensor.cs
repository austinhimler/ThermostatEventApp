using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThermostatEventApp.Interfaces;

namespace ThermostatEventApp.Models
{
    public class HeatSensor : IHeatSensor
    {
        double _warningLevel = 0;
        double _emergencyLevel = 0;
        bool _hasReachedWarningTemp = false;

        protected EventHandlerList _listEventDelegates = new EventHandlerList();

        static readonly object _temperatureWarningLevelKey = new object();
        static readonly object _temperatureFallsBelowWarningLevelKey = new object();
        static readonly object _temperatureEmergencyLevelKey = new object();

        private double[] _temperatureData = null;

        public HeatSensor(double warningLevel, double emergencyLevel)
        {
            _warningLevel = warningLevel;
            _emergencyLevel = emergencyLevel;

            SeedData();
        }
        private void SeedData()
        {
            _temperatureData = new double[] { 16, 17, 16.5, 18, 19, 22, 24, 26.75, 28.7, 27.6, 26, 24, 22, 45, 68, 86.45 };
        }

        public void RunHeatSensor()
        {
            Console.WriteLine("Heat sensor is running...");
            MonitorTemperature();
        }

        private void MonitorTemperature()
        {
            foreach (double temperature in _temperatureData)
            {
                Console.ResetColor();
                Console.WriteLine($"DateTime: {DateTime.Now}, Temperature: {temperature}");

                if (temperature >= _emergencyLevel)
                {
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temperature,
                        CurrentDateTime = DateTime.Now
                    };
                    OnTemperatureReachesEmergencyLevel(e);
                }
                else if (temperature >= _warningLevel)
                {
                    _hasReachedWarningTemp = true;
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temperature,
                        CurrentDateTime = DateTime.Now
                    };
                    OnTemperatureReachesWarningLevel(e);
                }
                else if (temperature < _warningLevel && _hasReachedWarningTemp)
                {
                    _hasReachedWarningTemp = false;
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temperature,
                        CurrentDateTime = DateTime.Now
                    };
                    OnTemperatureFallsBelowWarningLevel(e);
                }

                Thread.Sleep(1000);
            }
        }

        protected void OnTemperatureReachesWarningLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventDelegates[_temperatureWarningLevelKey];
            if (handler != null )
            {
                handler(this, e);
            }
        }
        protected void OnTemperatureFallsBelowWarningLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventDelegates[_temperatureFallsBelowWarningLevelKey];
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected void OnTemperatureReachesEmergencyLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventDelegates[_temperatureEmergencyLevelKey];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TempEmergencyEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureEmergencyLevelKey, value);
            }
            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureEmergencyLevelKey, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TempWarningEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureWarningLevelKey, value);
            }
            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureWarningLevelKey, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TempBelowWarningEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureFallsBelowWarningLevelKey, value);
            }
            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureFallsBelowWarningLevelKey, value);
            }
        }
    }
}
