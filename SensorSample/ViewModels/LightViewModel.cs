using SensorSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Devices.Sensors;

namespace SensorSample.ViewModels
{
    public class LightViewModel : BindableBase
    {
        public void OnGetLight()
        {
            LightSensor sensor = LightSensor.GetDefault();
            if (sensor != null)
            {
                LightSensorReading reading = sensor.GetCurrentReading();
                Illuminance = $"Illuminance: {reading?.IlluminanceInLux}";
            }
            else
            {
                Illuminance = "Light sensor not found";
            }
        }
        public void OnGetLightReport()
        {
            LightSensor sensor = LightSensor.GetDefault();
            if (sensor != null)
            {
                sensor.ReportInterval = Math.Max(sensor.MinimumReportInterval, 1000);
                sensor.ReadingChanged += async (s, e) =>
                {
                    LightSensorReading reading = e.Reading;
                    await CoreApplication.MainView.Dispatcher.RunAsync(
                        Windows.UI.Core.CoreDispatcherPriority.Low, () =>
                         {
                             IlluminanceReport = $"{reading.IlluminanceInLux} {reading.Timestamp}";
                         });
                };
            }
            else
            {
                IlluminanceReport = "Light sensor not found";
            }
        }
        private string _illuminance;
        public string Illuminance
        {
            get => _illuminance;
            set => Set(ref _illuminance, value);
        }
        private string _illuminanceReport;
        public string IlluminanceReport
        {
            get => _illuminanceReport;
            set => Set(ref _illuminanceReport, value);
        }
    }
}
