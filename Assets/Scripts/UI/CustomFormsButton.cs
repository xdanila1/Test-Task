using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomFormsButton : MonoBehaviour
{
    private Image _img;

    void Start()
    {
        _img = GetComponent<Image>();
        _img.alphaHitTestMinimumThreshold = 0.5f;
    }

   
}
