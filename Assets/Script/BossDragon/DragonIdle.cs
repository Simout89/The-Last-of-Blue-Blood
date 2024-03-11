using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragonIdle : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    [SerializeField] private GameObject Body;
    [SerializeField] private Transform IdlePoint;
    private Vector3 idlePoint;
    public static UnityEvent<bool> OnBossIdle = new UnityEvent<bool>();
    private bool idle = false;

    private void Awake()
    {
        idlePoint = IdlePoint.position;
        OnBossIdle.AddListener(HandleBossIdle);
    }

    private void HandleBossIdle(bool arg0)
    {
        idle = arg0;
        Body.transform.DOMove(idlePoint, Speed).SetEase(Ease.Linear);
    }
}
