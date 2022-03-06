using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSizeController : MonoBehaviour
{
    public Material materialPointSize;
    public Slider sliderPointSize;

    void Start()
    {
        int val = PlayerPrefs.GetInt("point_size", 5);
        sliderPointSize.value = val;
        SetPointSize(val);
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("point_size", (int)sliderPointSize.value);
        PlayerPrefs.Save();
    }

    public void SetPointSize(float val)
    {
        materialPointSize.SetInt("_PointSize", (int)val);
    }
}
