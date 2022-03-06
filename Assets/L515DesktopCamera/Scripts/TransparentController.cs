using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentController : MonoBehaviour
{
    bool _isTransparent = false;
    public Kirurobo.UniWindowController controller;
    public Canvas mainCanvas;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isTransparent == false)
            {
                _isTransparent = true;
                controller.isTransparent = true;
                controller.isTopmost = true;
                mainCanvas.gameObject.SetActive(false);
            }

            else
            {
                _isTransparent = false;
                controller.isTransparent = false;
                controller.isTopmost = false;
                mainCanvas.gameObject.SetActive(true);
            }
        }

    }
}
