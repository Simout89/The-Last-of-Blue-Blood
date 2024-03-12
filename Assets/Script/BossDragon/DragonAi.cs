using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAi : MonoBehaviour
{
    [SerializeField] private float IdleTime = 15;
    [SerializeField] private float PatrolTime = 30;
    private bool fight = false;
    private void Awake()
    {
        DragonTrigger.OnBossFight.AddListener(HandleStartFight);
    }

    private void HandleStartFight(bool arg)
    {
        fight = true;
        StartCoroutine(Patrol());
    }

    private IEnumerator Idle()
    {

        DragonIdle.OnBossIdle.Invoke(true);
        yield return new WaitForSeconds(IdleTime);
        DragonIdle.OnBossIdle.Invoke(false);
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        DragonPatrol.OnBossPatrol.Invoke(true);
        yield return new WaitForSeconds(PatrolTime);
        DragonPatrol.OnBossPatrol.Invoke(false);
        StartCoroutine(Idle());
    }
}
