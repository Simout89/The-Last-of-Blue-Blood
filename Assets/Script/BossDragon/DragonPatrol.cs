using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragonPatrol : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    [SerializeField] private GameObject Body;
    [SerializeField] private Transform Point1;
    [SerializeField] private Transform Point2;
    public static UnityEvent<bool> OnBossPatrol = new UnityEvent<bool>();
    private Vector3 point1;
    private Vector3 point2;
    private bool Target = false; // point1 = false, point2 = true
    private bool Patrol = false;
    private void Awake()
    {
        point1 = Point1.transform.position;
        point2 = Point2.position;
        OnBossPatrol.AddListener(HandleBossPatrol);
    }

    private void HandleBossPatrol(bool arg0)
    {
        Patrol = arg0;
        GoPoint1();
    }
    private void GoPoint1()
    {
        if(Patrol)
        {
            Body.transform.DOMove(point2, Speed).SetEase(Ease.Linear).OnComplete(GoPoint2);
        }
    }
    private void GoPoint2()
    {
        if (Patrol)
        {
            Body.transform.DOMove(point1, Speed).SetEase(Ease.Linear).OnComplete(GoPoint1);
        }
    }
}
