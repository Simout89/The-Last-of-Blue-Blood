using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudBossBar : MonoBehaviour
{
    [SerializeField] Slider BossBar;
    [SerializeField] GameObject BossBarHud;
    private bool first = true;
    private void Awake()
    {
        DragonTrigger.OnBossFight.AddListener(HandleBossFight);
        DragonHealth.OnGetDamage.AddListener(HandleGetDamage);
    }

    private void HandleBossFight(bool arg0)
    {
        BossBarHud.SetActive(true);
    }

    private void HandleGetDamage(int arg0)
    {
        if(first)
        {
            BossBar.maxValue = arg0;
            BossBar.value = arg0;
            first = false;
        }else
        {
            BossBar.value = arg0;
        }
    }
}
