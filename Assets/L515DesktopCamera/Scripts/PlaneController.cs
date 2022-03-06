using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public Slider slider;
    public Transform plane;

    void Start()
    {
        float val = PlayerPrefs.GetFloat("plane_position_z", 0.7f);
        slider.value = val;
        SetPlanePositonZ(val);
    }

    void OnDestroy()
    {
        float val = plane.position.z;
        PlayerPrefs.SetFloat("plane_position_z", val);
        PlayerPrefs.Save();
    }

    public void SetPlanePositonZ(float val)
    {
        Vector3 old_p = plane.position;
        Vector3 new_p = new Vector3(old_p.x, old_p.y, val);
        plane.position = new_p;
    }

}
