using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Intel.RealSense;

public class RsDeviceController : MonoBehaviour
{
    public RsDevice rsDevice;

    void Start()
    {
        var sensors = rsDevice.ActiveProfile.Device.Sensors;
        foreach (var s in sensors)
        {
            // sensorNames in L515 : L500 Depth Sensor, RGB Camera, Motion Module
            var sensorName = s.Info[CameraInfo.Name];
            if (sensorName.Contains("Depth"))
            {
                Debug.Log($"sensorName={sensorName}");

                foreach (var opt in s.Options)
                {
                    Debug.Log($"{opt.Key}");
                }

                s.Options[Option.LaserPower].Value = 10.0f;
                s.Options[Option.MinDistance].Value = 0.0f;

                break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
