using SensorSample.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Devices.Enumeration.Pnp;
using Windows.Devices.Sensors;
using Windows.UI.Core;
using Windows.UI.Input;

namespace SensorSample.ViewModels
{
    public class CompassViewModel : BindableBase
    {
        public void OnGetCompass()
        {
            Compass sensor = Compass.GetDefault();
            if (sensor != null)
            {
                CompassReading reading = sensor.GetCurrentReading();
                CompassInfo = $"magnetic north: {reading.HeadingMagneticNorth} " +
                    $"real north: {reading.HeadingTrueNorth}, " +
                    $"accuracy: {reading.HeadingAccuracy}";
            }
            else
            {
                CompassInfo = "Compass sensor not found";
            }
        }
        public void OnGetCompassReport()
        {
            Compass sensor = Compass.GetDefault();
            if (sensor != null)
            {
                sensor.ReportInterval = Math.Max(sensor.MinimumReportInterval, 1000);
                sensor.ReadingChanged += async (s, e) =>
                {
                    CompassReading reading = e.Reading;
                    await CoreApplication.MainView.Dispatcher.RunAsync(
                        CoreDispatcherPriority.Low, () =>
                         {
                             CompassInfoReport = $"magnetic north: {reading.HeadingMagneticNorth} " +
                             $"real north: {reading.HeadingTrueNorth}, " +
                             $"accuracy: {reading.HeadingAccuracy}";
                         });
                };
            }
            else
            {
                CompassInfoReport = "Compass sensor not found";
            }
        }
        public string _compassInfo;
        public string CompassInfo
        {
            get => _compassInfo;
            set => Set(ref _compassInfo, value);
        }
        public string _compassInfoReport;
        public string CompassInfoReport
        {
            get => _compassInfoReport;
            set => Set(ref _compassInfoReport, value);
        }
    }
}
