using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HudAmmoImage : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        Gun.OnFire.AddListener(HandleFire);
    }
    private void HandleFire(int bullet)
    {
        if (bullet == 0)
            image.color = Color.gray;
        else 
            image.color = Color.white;
    }
}
