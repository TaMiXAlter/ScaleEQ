using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayTimer : MonoBehaviour
{
    private Slider _slider;
    

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    
    public void SetSliderValue(float value)
    {
        _slider.value = value;
    }
}   
