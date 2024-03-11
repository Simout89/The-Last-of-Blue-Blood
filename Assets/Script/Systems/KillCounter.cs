using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillCounter : MonoBehaviour
{
    public int goblin = 0;
    public static UnityEvent OnKill = new UnityEvent();
    private void Awake()
    {
        OnKill.AddListener(HandleKill);
    }

    private void HandleKill()
    {
        goblin++;
        Debug.Log(goblin);
    }
}
