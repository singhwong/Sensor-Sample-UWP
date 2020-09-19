using SensorSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Sensors;
using Windows.System.RemoteSystems;

namespace SensorSample.ViewModels
{
    public class InclinometerViewModel : BindableBase
    {
        public void OnGetInclinometer()
        {
            Inclinometer sensor = Inclinometer.GetDefault();
            if (sensor != null)
            {
                InclinometerReading reading = sensor.GetCurrentReading();
                InclinometerInfo = $"pitch degrees: {reading.PitchDegrees} " +
                    $"rool degrees: {reading.RollDegrees} " +
                    $"yaw accuracy: {reading.YawAccuracy} " +
                    $"yaw degrees: {reading.YawDegrees}";
            }
            else
            {
                InclinometerInfo = "Inclinometer sensor not found";
            }
        }
        private string _inclinometerInfo;
        public string InclinometerInfo
        {
            get => _inclinometerInfo;
            set => Set(ref _inclinometerInfo, value);
        }
    }
}
