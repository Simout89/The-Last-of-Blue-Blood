using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudAmmo : MonoBehaviour
{
    private TMP_Text _ammo;
    private void Start()
    {
        _ammo = GetComponent<TMP_Text>();
        EventManager.Fire.AddListener(ChangeText);
    }

    private void ChangeText(int bullet)
    {
        if(bullet <= 0)
        {
            _ammo.text = "Reload...";
        }else
            _ammo.text = $"Ammo: {bullet}";

    }
}
