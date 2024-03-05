using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent<int> Fire = new UnityEvent<int>();
    public static UnityEvent<bool> Ground = new UnityEvent<bool>();
    public static UnityEvent<bool> Squat = new UnityEvent<bool>();
    public static UnityEvent Princess = new UnityEvent();
    public static UnityEvent Finish = new UnityEvent();
    public static UnityEvent DamagePlayer = new UnityEvent();

    public static void isGround(bool flag)
    {
        Ground.Invoke(flag);
    }
}
