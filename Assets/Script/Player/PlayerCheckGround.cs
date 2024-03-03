using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerCheckGround : MonoBehaviour
{
    public static UnityEvent<bool> IsGround = new UnityEvent<bool>();

    private void OnTriggerEnter(Collider other)
    {
        IsGround.Invoke(true);
    }
    private void OnTriggerExit(Collider other)
    {
        IsGround.Invoke(false);
    }
}
