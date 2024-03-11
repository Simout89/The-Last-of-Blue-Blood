using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TotalTime : MonoBehaviour
{
    public static UnityEvent OnResetTime = new UnityEvent();
    public static UnityEvent<float> OnTime = new UnityEvent<float>();

    public float totalTime = 0;

    private void Awake()
    {
        OnResetTime.AddListener(HandleResetTime);
        OnTime.AddListener(HandleTime);
    }

    private void HandleResetTime()
    {
        totalTime = 0;
        Debug.Log("Time Reset");
    }

    private void HandleTime(float arg0)
    {
        totalTime += arg0;
        Debug.Log(totalTime);
    }
}
