using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : MonoBehaviour
{
    private bool _playernear = false;
    private void Awake()
    {
        GoblinPlayerDetection.OnPlayerNear.AddListener(HandlePlayerNear);
    }
    private void HandlePlayerNear(bool flag)
    {
        _playernear = flag;
    }
    private void Update()
    {
        if(_playernear)
        {
            GoblinBerserk.OnBerserk.Invoke();
        }else
        {
            GoblinPointWalk.OnPointWalk.Invoke();
        }
    }
}
