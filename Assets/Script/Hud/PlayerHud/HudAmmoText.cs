using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudAmmo : MonoBehaviour
{
    private TMP_Text Text;
    private void Start()
    {
        Text = GetComponent<TMP_Text>();
        Gun.OnFire.AddListener(HandleFire);
    }

    private void HandleFire(int bullet)
    {
        Text.text = bullet.ToString();
    }
}
