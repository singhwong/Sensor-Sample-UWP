using SensorSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Sensors;
using Windows.UI.Composition.Scenes;

namespace SensorSample.ViewModels
{
    public class GyrometerViewModel : BindableBase
    {
        public void OnGetGyrometer()
        {
            Gyrometer sensor = Gyrometer.GetDefault();
            if (sensor != null)
            {
                GyrometerReading reading = sensor.GetCurrentReading();
                GyrometerInfo = $"X: {reading.AngularVelocityX} " +
                    $"Y: {reading.AngularVelocityY} Z: {reading.AngularVelocityZ}";
            }
            else
            {
                GyrometerInfo = "Gyrometer sensor not found";
            }
        }
        private string _gyrometerInfo;
        public string GyrometerInfo
        {
            get => _gyrometerInfo;
            set => Set(ref _gyrometerInfo, value);
        }
    }
}
