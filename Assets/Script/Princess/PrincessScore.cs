using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class PrincessScore : MonoBehaviour
{
    public int PrincessCount { get; private set; }
    public int MaxPrincess { get; private set; }
    private GameObject[] princess;
    private void Awake()
    {
        princess = GameObject.FindGameObjectsWithTag("Princess");
        PrincessCount = 0;
        PrincessCollect.OnCollectPrincess.AddListener(HandlePrincessCollect);
        MaxPrincess = princess.Length;
    }
    private void HandlePrincessCollect()
    {
        PrincessCount++;
    }
}
