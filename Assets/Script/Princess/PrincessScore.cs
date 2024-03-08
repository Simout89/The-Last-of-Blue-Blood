using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessScore : MonoBehaviour
{
    public int PrincessCount { get; private set; }
    private void Awake()
    {
        PrincessCount = 0;
        PrincessCollect.OnCollectPrincess.AddListener(HandlePrincessCollect);
    }
    private void HandlePrincessCollect()
    {
        PrincessCount++;
    }
}
