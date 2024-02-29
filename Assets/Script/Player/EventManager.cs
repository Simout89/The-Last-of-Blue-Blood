using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent<int> Fire = new UnityEvent<int>();
    public static UnityEvent<bool> Ground = new UnityEvent<bool>();
    public static UnityEvent Princess = new UnityEvent();
    public static UnityEvent Finish = new UnityEvent();
    public static void Shot(int bullet)
    {
        Fire.Invoke(bullet);
    }
    public static void isGround(bool flag)
    {
        Ground.Invoke(flag);
    }

    public static void PrincessCollect()
    {
        Princess.Invoke();
    }
    public static void finish()
    {
        Finish.Invoke();
    }
}
