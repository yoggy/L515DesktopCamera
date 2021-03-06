using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionRestore : MonoBehaviour
{
    public Transform mainCamera;

    Vector3 lastCameraPosition;
    Vector3 lastCameraEulerAngles;

    void Start()
    {
        float x = PlayerPrefs.GetFloat("camera_x", mainCamera.position.x);
        float y = PlayerPrefs.GetFloat("camera_y", mainCamera.position.y);
        float z = PlayerPrefs.GetFloat("camera_z", mainCamera.position.z);

        float pitch = PlayerPrefs.GetFloat("camera_pitch", mainCamera.eulerAngles.x);
        float yaw = PlayerPrefs.GetFloat("camera_yaw", mainCamera.eulerAngles.y);
        float roll = PlayerPrefs.GetFloat("camera_roll", mainCamera.eulerAngles.z);

        mainCamera.position = new Vector3(x, y, z);
        mainCamera.eulerAngles = new Vector3(pitch, yaw, roll);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPosition();
        }

        lastCameraPosition = mainCamera.position;
        lastCameraEulerAngles = mainCamera.eulerAngles;
    }

    void OnDestroy()
    {
        PlayerPrefs.SetFloat("camera_x", lastCameraPosition.x);
        PlayerPrefs.SetFloat("camera_y", lastCameraPosition.y);
        PlayerPrefs.SetFloat("camera_z", lastCameraPosition.z);

        PlayerPrefs.SetFloat("camera_pitch", lastCameraEulerAngles.x);
        PlayerPrefs.SetFloat("camera_yaw", lastCameraEulerAngles.y);
        PlayerPrefs.SetFloat("camera_roll", lastCameraEulerAngles.z);
    }

    public void ResetPosition()
    {
        mainCamera.position = new Vector3(0, 0, 0.2f);
        mainCamera.rotation = Quaternion.identity;
    }
}
