using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryCount : MonoBehaviour
{
    public int DeathCount = 0;
    private void Awake()
    {
        HudTimer.FixTime.AddListener(HandleDeath);
        TotalTime.OnResetTime.AddListener(HandleRestart);

    }

    private void HandleRestart()
    {
        DeathCount = 0;
    }

    private void HandleDeath()
    {
        DeathCount++;
    }
}
