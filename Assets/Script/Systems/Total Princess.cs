using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TotalPrincess : MonoBehaviour
{
    public int MaxPrincessOnScene = 0;
    public int MaxPrincess = 0;
    public int CountPrincess = 0;
    public int NowCountPrincess = 0;
    private void Awake()
    {
        MaxPrincessOnScene = GameObject.FindGameObjectsWithTag("Princess").Length;
        PrincessCollect.OnCollectPrincess.AddListener(HandleCollectPrincess);
        HudFinishMenuButtons.OnRestart.AddListener(HandleRestart);
        HudFinishMenuButtons.OnNext.AddListener(HandleNext);
        TotalTime.OnResetTime.AddListener(HandlePrincessReset);
        HudTimer.FixTime.AddListener(HandleRestart);
    }

    private void HandleCollectPrincess()
    {
        NowCountPrincess++;
    }

    private void HandleNext()
    {
        MaxPrincess += MaxPrincessOnScene;
        CountPrincess += NowCountPrincess;
        NowCountPrincess = 0;
        StartCoroutine(delay());
    }

    private void HandleRestart()
    {
        NowCountPrincess = 0;
    }

    private void HandlePrincessReset()
    {
        MaxPrincess = 0;
        CountPrincess = 0;
        NowCountPrincess = 0;
        Debug.Log("Princerss Reset");
    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        MaxPrincessOnScene = GameObject.FindGameObjectsWithTag("Princess").Length;
    }
}
