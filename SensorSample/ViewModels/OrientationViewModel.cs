using SensorSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Sensors;

namespace SensorSample.ViewModels
{
    public class OrientationViewModel : BindableBase
    {
        public void OnGetOrientation()
        {
            OrientationSensor sensor = OrientationSensor.GetDefault();
            if (sensor != null)
            {
                OrientationSensorReading reading = sensor.GetCurrentReading();
                OrientataionInfo = $"Quaternion: {reading.Quaternion.Output()} " +
                    $"Rotation: {reading.RotationMatrix.Output()} " +
                    $"Yaw accuracy: {reading.YawAccuracy}";
            }
            else
            {
                OrientataionInfo = "Orientation sensor not found";
            }
        }
        private string _orientationInfo;
        public string OrientataionInfo
        {
            get => _orientationInfo;
            set => Set(ref _orientationInfo, value);
        }
    }
    public static class OrientationSensorExtensions
    {
        public static string Output(this SensorQuaternion q) =>
        $"x {q.X} y {q.Y} z {q.Z} w {q.W}";
        public static string Output(this SensorRotationMatrix m) =>
            $"m11 {m.M11} m12 {m.M12} m13 {m.M13}\n" +
            $"m21 {m.M21} m22 {m.M22} m23 {m.M23}\n" +
            $"m31 {m.M31} m32 {m.M32} m33 {m.M33}";
    }
}
