using SensorSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Printers;
using Windows.Devices.Sensors;

namespace SensorSample.ViewModels
{
    public class AccelerometerViewModel : BindableBase
    {
        public void OnGetAccelerometer()
        {
            Accelerometer sensor = Accelerometer.GetDefault();
            if (sensor != null)
            {
                AccelerometerReading reading = sensor.GetCurrentReading();
                AccelerometerInfo = $"X: {reading.AccelerationX} " +
                    $"Y: {reading.AccelerationY} Z: {reading.AccelerationZ}";
            }
            else
            {
                AccelerometerInfo = "Accelerometer sensor not found";
            }
        }
        private string _accelerometerInfo;
        public string AccelerometerInfo
        {
            get => _accelerometerInfo;
            set => Set(ref _accelerometerInfo, value);
        }
    }
}
