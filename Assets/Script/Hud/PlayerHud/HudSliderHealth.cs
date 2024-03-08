using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class HudSliderHealth : MonoBehaviour
{
    private Slider slider;
    private int _count;
    private void Awake()
    {
        PlayerHealth.OnChangeHealth.AddListener(HandleChangeHealth);
        slider = GetComponent<Slider>();
    }
    private void HandleChangeHealth(int health)
    {
        if (_count == 0)
        {
            _count++;
            slider.maxValue = health;
        }
        slider.value = health;
    }
}
